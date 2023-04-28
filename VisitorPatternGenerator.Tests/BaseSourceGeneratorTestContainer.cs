using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing.Verifiers;

using RoseLynn.Testing;

using VisitorPatternGenerator.Tests.Verifiers;

namespace VisitorPatternGenerator.Tests;

public abstract class BaseSourceGeneratorTestContainer<TGenerator>: BaseIncrementalGeneratorTestContainer<TGenerator, NUnitVerifier, CSharpSourceGeneratorVerifier<TGenerator>.Test>
    where TGenerator : IIncrementalGenerator, new()
{
    protected override LanguageVersion LanguageVersion => LanguageVersion.CSharp11;
}
