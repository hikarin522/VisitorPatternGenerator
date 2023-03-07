
using System.Collections.Immutable;

using Microsoft.CodeAnalysis;

namespace VisitorPatternGenerator.Templates;

partial class AcceptorTemplate
{
    internal AcceptorOptions Options { get; }

    internal INamedTypeSymbol Acceptor { get; }

    internal ImmutableSortedSet<INamedTypeSymbol> Acceptors { get; }

    internal AcceptorTemplate(
        AcceptorOptions options,
        INamedTypeSymbol acceptor,
        ImmutableSortedSet<INamedTypeSymbol> acceptors
    )
    {
        this.Options = options;
        this.Acceptor = acceptor;
        this.Acceptors = acceptors;
    }
}
