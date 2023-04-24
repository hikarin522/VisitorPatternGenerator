using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

using RoseLynn.Generators;
using RoseLynn.Testing;

using VisitorPatternGenerator.Tests.Verifiers;

using TupleSourceMappings = System.Collections.Generic.IEnumerable<(string fileName, string source)>;

namespace VisitorPatternGenerator.Tests;

public abstract class BaseSourceGeneratorTestContainer<TSourceGenerator>
    where TSourceGenerator : IIncrementalGenerator, new()
{
    protected LanguageVersion LanguageVersion => LanguageVersion.CSharp11;

    protected virtual OutputKind OutputKind => OutputKind.NetModule;

    protected Compilation CreateCompilationRunGenerator(string source, out TSourceGenerator generator, out GeneratorDriver resultingGeneratorDriver, out Compilation initialCompilation, CancellationToken cancellationToken = default)
    {
        return this.CreateCompilationRunGenerator(new[] { source }, out generator, out resultingGeneratorDriver, out initialCompilation, cancellationToken);
    }

    protected Compilation CreateCompilationRunGenerator(IEnumerable<string> sources, out TSourceGenerator generator, out GeneratorDriver resultingGeneratorDriver, out Compilation initialCompilation, CancellationToken cancellationToken = default)
    {
        var defaultMetadataReferences = Enumerable.Empty<MetadataReference>();
        var parseOptions = new CSharpParseOptions(this.LanguageVersion);
        var syntaxTrees = sources.Select((string source) => CSharpSyntaxTree.ParseText(source, parseOptions));
        var options = new CSharpCompilationOptions(this.OutputKind);
        initialCompilation = CSharpCompilation.Create(null, syntaxTrees, defaultMetadataReferences, options);
        generator = new TSourceGenerator();
        var cSharpGeneratorDriver = CSharpGeneratorDriver.Create(generator);
        resultingGeneratorDriver = cSharpGeneratorDriver.RunGeneratorsAndUpdateCompilation(initialCompilation, out var outputCompilation, out var _, cancellationToken);
        return outputCompilation;
    }

    protected async Task VerifyAsync(string source, string generatedHintName, string generatedSource, CancellationToken cancellationToken = default)
    {
        var mappings = new GeneratedSourceMappings
        {
            { generatedHintName, generatedSource }
        };
        await this.VerifyAsync(source, mappings, cancellationToken);
    }

    protected async Task VerifyAsync(string source, GeneratedSourceMappings mappings, CancellationToken cancellationToken = default)
    {
        await this.VerifyAsync(new[] { source }, mappings, cancellationToken);
    }

    protected async Task VerifyAsync(string source, TupleSourceMappings mappings, CancellationToken cancellationToken = default)
    {
        await this.VerifyAsync(new[] { source }, mappings, new CSharpSourceGeneratorVerifier<TSourceGenerator>.Test(), cancellationToken);
    }

    protected async Task VerifyAsync(string source, GeneratedSourceMappings mappings, CSharpSourceGeneratorVerifier<TSourceGenerator>.Test test, CancellationToken cancellationToken = default)
    {
        await this.VerifyAsync(new[] { source }, mappings, test, cancellationToken);
    }

    protected async Task VerifyAsync(IEnumerable<string> sources, GeneratedSourceMappings mappings, CancellationToken cancellationToken = default)
    {
        await this.VerifyAsync(sources, mappings, new CSharpSourceGeneratorVerifier<TSourceGenerator>.Test(), cancellationToken);
    }

    protected async Task VerifyAsync(IEnumerable<string> sources, GeneratedSourceMappings mappings, CSharpSourceGeneratorVerifier<TSourceGenerator>.Test test, CancellationToken cancellationToken = default)
    {
        test.TestState.Sources.AddRange(sources);
        foreach (var mapping in mappings) {
            test.TestState.GeneratedSources.Add((typeof(TSourceGenerator), mapping.Key, mapping.Value));
        }

        await test.RunAsync(cancellationToken);
    }

    protected async Task VerifyAsync(IEnumerable<string> sources, IEnumerable<(string fileName, SourceText source)> mappings, CSharpSourceGeneratorVerifier<TSourceGenerator>.Test test, CancellationToken cancellationToken = default)
    {
        test.TestState.Sources.AddRange(sources);
        foreach (var (fileName, source) in mappings) {
            test.TestState.GeneratedSources.Add((typeof(TSourceGenerator), fileName, source));
        }

        await test.RunAsync(cancellationToken);
    }
    protected async Task VerifyAsync(IEnumerable<string> sources, TupleSourceMappings mappings, CSharpSourceGeneratorVerifier<TSourceGenerator>.Test test, CancellationToken cancellationToken = default)
    {
        test.TestState.Sources.AddRange(sources);
        foreach (var (fileName, source) in mappings) {
            test.TestState.GeneratedSources.Add((typeof(TSourceGenerator), fileName, source));
        }

        await test.RunAsync(cancellationToken);
    }
}
