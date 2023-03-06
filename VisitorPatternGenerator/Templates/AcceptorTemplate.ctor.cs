
using System.Collections.Immutable;

using Microsoft.CodeAnalysis;

namespace VisitorPatternGenerator.Templates;

partial class AcceptorTemplate
{
    internal AcceptorOptions Options { get; }

    internal INamedTypeSymbol AcceptorInterface { get; }

    internal ImmutableSortedSet<INamedTypeSymbol> AcceptorTypes { get; }

    internal AcceptorTemplate(
        AcceptorOptions options,
        INamedTypeSymbol acceptorInterface,
        ImmutableSortedSet<INamedTypeSymbol> acceptorTypes
    )
    {
        this.Options = options;
        this.AcceptorInterface = acceptorInterface;
        this.AcceptorTypes = acceptorTypes;
    }
}
