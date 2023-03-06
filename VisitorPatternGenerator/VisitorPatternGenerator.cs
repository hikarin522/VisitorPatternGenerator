using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using VisitorPatternGenerator.Templates;

namespace VisitorPatternGenerator;

[Generator]
public class VisitorPatternGenerator: IIncrementalGenerator
{
    public static string AcceptorAttributeName { get; } = typeof(AcceptorAttribute).FullName;

    public static IReadOnlyList<string> AcceptorAttributeNames { get; } = new[] {
        typeof(AcceptorAttribute<>).FullName,
        typeof(AcceptorAttribute<,>).FullName,
    };

    public static IReadOnlyList<string> VisitorAttributeNames { get; } = new[] {
        typeof(VisitorAttribute<>).FullName,
        typeof(VisitorAttribute<,>).FullName,
        typeof(TaskVisitorAttribute<>).FullName,
        typeof(TaskVisitorAttribute<,>).FullName,
        typeof(ValueTaskVisitorAttribute<>).FullName,
        typeof(ValueTaskVisitorAttribute<,>).FullName,
    };

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static ctx => {
            ctx.CancellationToken.ThrowIfCancellationRequested();

            var template = new AnnotationsTemplate();
            ctx.AddSource(nameof(AnnotationsTemplate), template.TransformText());
        });

        var optionsProvider = context.AnalyzerConfigOptionsProvider.Select(static (options, ct) => {
            ct.ThrowIfCancellationRequested();
            options.GlobalOptions.TryGetValue("build_property.RootNamespace", out var rootNamespace);
            rootNamespace = string.IsNullOrWhiteSpace(rootNamespace) ? string.Empty : rootNamespace!;
            options.GlobalOptions.TryGetValue("build_property.VisitorPatternGeneratorNonPublic", out var nonPublicString);
            var nonPublic = string.Equals(nonPublicString, "true", StringComparison.OrdinalIgnoreCase);
            return (rootNamespace, nonPublic);
        });

        context.RegisterSourceOutput(optionsProvider, static (ctx, e) => {
            var (rootNamespace, nonPublic) = e;
            ctx.CancellationToken.ThrowIfCancellationRequested();

            var template = new InterfacesTemplate(rootNamespace, nonPublic);
            ctx.AddSource(nameof(InterfacesTemplate), template.TransformText());
        });

        var acceptors = AcceptorAttributeNames.Select(e => context.SyntaxProvider.ForAttributeWithMetadataName(e).Collect())
            .Aggregate(static (l, r) => l.Combine(r).Select(static (e, ct) => {
                ct.ThrowIfCancellationRequested();
                return e.Left.AddRange(e.Right);
            })).Select(static (e, ct) => {
                ct.ThrowIfCancellationRequested();
                return e.ToLookup(static e => (INamedTypeSymbol)e.Attributes[0].AttributeClass!.TypeArguments[0], (IEqualityComparer<INamedTypeSymbol>)SymbolEqualityComparer.Default)
                    .ToImmutableDictionary(static e => e.Key!, static e => e.ToImmutableArray(), (IEqualityComparer<INamedTypeSymbol>)SymbolEqualityComparer.Default);
            });

        var acceptor = context.SyntaxProvider.ForAttributeWithMetadataName(AcceptorAttributeName);
        var acceptorProvider = acceptor.Combine(acceptors).Select(static (e, ct) => {
            ct.ThrowIfCancellationRequested();
            var acceptorInterface = (INamedTypeSymbol)e.Left.TargetSymbol;
            var acceptors = e.Right.GetValueOrDefault(acceptorInterface);
            return (e.Left, acceptors);
        });

        context.RegisterSourceOutput(acceptorProvider, static (ctx, e) => {
            var (acceptor, acceptors) = e;
            ctx.CancellationToken.ThrowIfCancellationRequested();
            _AddAcceptorSource(ctx, acceptor, acceptors);
        });

        foreach (var attrName in VisitorAttributeNames) {
            var visitor = context.SyntaxProvider.ForAttributeWithMetadataName(attrName);
            var visitorProvider = visitor.Combine(acceptors).Select(static (e, ct) => {
                ct.ThrowIfCancellationRequested();
                var acceptorInterface = (INamedTypeSymbol)e.Left.Attributes[0].AttributeClass!.TypeArguments[0];
                var acceptors = e.Right.GetValueOrDefault(acceptorInterface);
                return (e.Left, acceptors);
            }).Combine(optionsProvider);

            context.RegisterSourceOutput(visitorProvider, static (ctx, e) => {
                var ((visitor, acceptors), (rootNamespace, _)) = e;
                ctx.CancellationToken.ThrowIfCancellationRequested();
                _AddVisitorSource(ctx, rootNamespace, visitor, acceptors);
            });
        }
    }

    private static void _AddAcceptorSource(SourceProductionContext ctx, GeneratorAttributeSyntaxContext acceptor, ImmutableArray<GeneratorAttributeSyntaxContext> acceptors)
    {
        var acceptorSymbol = (INamedTypeSymbol)acceptor.TargetSymbol;

        var acceptorAttr = acceptor.Attributes[0];

        var options = (AcceptorOptions)acceptorAttr.ConstructorArguments[0].Value!;

        var acceptorTypes = acceptors
            .Select(static e => (INamedTypeSymbol)e.TargetSymbol)
            .ToImmutableSortedSet(Comparer<INamedTypeSymbol>.Create(static (l, r) => string.Compare(_GetFileName(l), _GetFileName(r))));

        var template = new AcceptorTemplate(options, acceptorSymbol, acceptorTypes);
        ctx.AddSource(_GetFileName(acceptorSymbol), template.TransformText());
    }

    private static void _AddVisitorSource(SourceProductionContext ctx, string rootNamespace, GeneratorAttributeSyntaxContext visitor, ImmutableArray<GeneratorAttributeSyntaxContext> acceptors)
    {
        var visitorSymbol = (INamedTypeSymbol)visitor.TargetSymbol;

        var attr = visitor.Attributes[0];
        var attrSymbol = attr.AttributeClass!;

        var taskName = attrSymbol.Name.SkipLast("VisitorAttribute".Length);

        var attrTypeArgs = attrSymbol.TypeArguments;
        var acceptorSymbol = (INamedTypeSymbol)attrTypeArgs[0];
        var baseResultSymbol = attrTypeArgs.ElementAtOrDefault(1) as INamedTypeSymbol;

        var attrArgs = attr.ConstructorArguments;
        bool? voidReturn = attrArgs.IsEmpty ? null : (bool)attrArgs[0].Value!;

        var typeParams = visitorSymbol.TypeParameters;
        var nonGenericReturn = typeParams.IsEmpty || baseResultSymbol is not null || voidReturn == true;
        ITypeSymbol? baseResultType = nonGenericReturn ? baseResultSymbol : typeParams.Last();

        var acceptorTypes = acceptors
            .Select(static e => ((INamedTypeSymbol)e.TargetSymbol, e.Attributes[0].AttributeClass!.TypeArguments.ElementAtOrDefault(1) as INamedTypeSymbol))
            .ToImmutableArray();

        var template = new VisitorTemplate(
            rootNamespace,
            taskName,
            baseResultType,
            visitorSymbol,
            acceptorSymbol,
            acceptorTypes
        );
        ctx.AddSource(_GetFileName(visitorSymbol), template.TransformText());
    }

    private static string _GetFileName(INamedTypeSymbol symbol)
        => (symbol.ContainingNamespace.IsGlobalNamespace ? string.Empty : symbol.ContainingNamespace.ToDisplayString() + ".") + symbol.MetadataName;
}

public static class DiagnosticDescriptors
{
    const string CATEGORY = nameof(VisitorPatternGenerator);

    public static DiagnosticDescriptor TypeParamCountError { get; } = new(
        id: $"{CATEGORY}003",
        title: "Type parameter count must equal argument count + wrapType type parameter count",
        messageFormat: "'{0}' type parameters are required.",
        category: CATEGORY,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true
    );
}
