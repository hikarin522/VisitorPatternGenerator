using System;
using System.Threading;

namespace Microsoft.CodeAnalysis;

internal static class SyntaxValueProviderExtensions
{
    public static IncrementalValuesProvider<GeneratorAttributeSyntaxContext> ForAttributeWithMetadataName<T>(this SyntaxValueProvider @this, Func<SyntaxNode, CancellationToken, bool>? predicate = null)
        where T : Attribute => @this.ForAttributeWithMetadataName(typeof(T), predicate);

    public static IncrementalValuesProvider<GeneratorAttributeSyntaxContext> ForAttributeWithMetadataName(this SyntaxValueProvider @this, Type type, Func<SyntaxNode, CancellationToken, bool>? predicate = null)
        => @this.ForAttributeWithMetadataName(type.FullName, predicate);

    public static IncrementalValuesProvider<GeneratorAttributeSyntaxContext> ForAttributeWithMetadataName(this SyntaxValueProvider @this, string fullyQualifiedMetadataName, Func<SyntaxNode, CancellationToken, bool>? predicate = null)
        => @this.ForAttributeWithMetadataName(fullyQualifiedMetadataName, predicate ?? (static (_, _) => true), static (ctx, _) => ctx);
}
