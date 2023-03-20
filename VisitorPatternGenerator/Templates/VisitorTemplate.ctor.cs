using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis;

namespace VisitorPatternGenerator.Templates;

partial class VisitorTemplate
{
    public string RootNamespace { get; }

    public string TaskName { get; }

    public ITypeSymbol? BaseResult { get; }

    public INamedTypeSymbol Visitor { get; }

    public INamedTypeSymbol Acceptor { get; }

    public ImmutableArray<(INamedTypeSymbol Type, INamedTypeSymbol? SelfType, INamedTypeSymbol? ResultType)> Acceptors { get; }

    public VisitorTemplate(
        string rootNamespace,
        string taskName,
        ITypeSymbol? baseResult,
        INamedTypeSymbol visitor,
        INamedTypeSymbol acceptor,
        ImmutableArray<(INamedTypeSymbol Type, INamedTypeSymbol? SelfType, INamedTypeSymbol? ResultType)> acceptors
    )
    {
        this.RootNamespace = rootNamespace;
        this.TaskName = taskName;
        this.BaseResult = baseResult;
        this.Visitor = visitor;
        this.Acceptor = acceptor;
        this.Acceptors = acceptors;
    }

    public bool IsAsync => !string.IsNullOrWhiteSpace(this.TaskName);

    public string IfAsync(string str) => this.IsAsync ? str : string.Empty;

    public bool IsGeneric => this.BaseResult is ITypeParameterSymbol;

    public string GetTypeParamStr()
    {
        var typeParams = this.Visitor.TypeParameters;
        return typeParams.IsEmpty ? string.Empty : $"<{string.Join(", ", typeParams.Select(static e => e.ToDisplayString()))}>";
    }

    public string GetArgListStr()
    {
        var argParams = this._GetArgParamList();
        return !argParams.Any() ? string.Empty : ", " + string.Join(", ", argParams.Select(static e => {
            return _GetArgName(e.ToDisplayString());
        }));
    }

    public string GetTypeArgListStr()
    {
        var argParams = this._GetArgParamList();
        return !argParams.Any() ? string.Empty : ", " + string.Join(", ", argParams.Select(static e => {
            var typeName = e.ToDisplayString();
            return $"{typeName} {_GetArgName(typeName)}";
        }));
    }

    private IEnumerable<ITypeParameterSymbol> _GetArgParamList()
    {
        var typeParams = this.Visitor.TypeParameters;
        return this.IsGeneric ? typeParams.SkipLast(1) : typeParams;
    }

    private static string _GetArgName(string typeName)
    {
        if (Regex.IsMatch(typeName, "^T[A-Z]")) {
            typeName = typeName.Substring(1);
        }
        return char.ToLower(typeName[0]) + typeName.Substring(1);
    }

    public string GetTypeConstraintList() => this.Visitor
        .ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat.WithGenericsOptions(SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeTypeConstraints))
        .Substring(this.Visitor.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat).Length);

    public string GetBaseInterfaceName(string name)
        => string.IsNullOrWhiteSpace(this.RootNamespace) ? name : $"{this.RootNamespace}.{name}";

    public string GetReturnType(ITypeSymbol? resultType)
    {
        var resultName = resultType?.ToDisplayString();
        var taskName = !this.IsAsync ? null : $"System.Threading.Tasks.{this.TaskName}";
        return resultName is null ? taskName ?? "void" : taskName is null ? resultName : $"{taskName}<{resultName}>";
    }

    public static string GetNamespace(INamedTypeSymbol type)
        => type.ContainingNamespace.ToDisplayString();

    public static string GetTypeIdentifier(INamedTypeSymbol type)
        => type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat.WithGenericsOptions(SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeVariance));
}
