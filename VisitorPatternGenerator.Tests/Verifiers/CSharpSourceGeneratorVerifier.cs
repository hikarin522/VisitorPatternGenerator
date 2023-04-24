using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing.Verifiers;

using RoseLynn.Generators.Testing;

namespace VisitorPatternGenerator.Tests.Verifiers;

public static class CSharpSourceGeneratorVerifier<TGenerator>
    where TGenerator : IIncrementalGenerator, new()
{
    public class Test: CSharpSourceGeneratorTestEx<InterfacingSourceGenerator, NUnitVerifier>
    {
        protected override IEnumerable<ISourceGenerator> GetSourceGenerators() => new[] { new TGenerator().AsSourceGenerator() };

        public Test()
        {
            this.ReferenceAssemblies = RuntimeReferences.NET7_0Reference;
        }
    }
}
