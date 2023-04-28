using System.IO;

using Microsoft.CodeAnalysis.Testing;

namespace VisitorPatternGenerator.Tests;

public static class RuntimeReferences
{
    public static readonly ReferenceAssemblies NET7_0Reference =
        new(
            "net7.0",
            new PackageIdentity(
                "Microsoft.NETCore.App.Ref", "7.0.0"),
                Path.Combine("ref", "net7.0"));
}
