using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing.Verifiers;

using RoseLynn.Testing;

namespace VisitorPatternGenerator.Tests.Verifiers;

public static class CSharpSourceGeneratorVerifier<TGenerator>
    where TGenerator : IIncrementalGenerator, new()
{
    public class Test: CSharpIncrementalGeneratorTestEx<TGenerator, NUnitVerifier>
    {
        public Test()
        {
            this.ReferenceAssemblies = RuntimeReferences.NET7_0Reference;
        }
    }
}
