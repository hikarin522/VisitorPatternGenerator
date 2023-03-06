using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis;

namespace VisitorPatternGenerator.Templates;

partial class VisitorTemplate
{
    public string RootNamespace { get; }

    public string TaskName { get; }

    public ITypeSymbol? BaseResultType { get; }

    public INamedTypeSymbol VisitorInterface { get; }

    public INamedTypeSymbol AcceptorInterface { get; }

    public ImmutableArray<(INamedTypeSymbol Type, INamedTypeSymbol? ResultType)> AcceptorTypes { get; }

    public VisitorTemplate(
        string rootNamespace,
        string taskName,
        ITypeSymbol? baseResultType,
        INamedTypeSymbol visitorInterface,
        INamedTypeSymbol acceptorInterface,
        ImmutableArray<(INamedTypeSymbol Type, INamedTypeSymbol? ResultType)> acceptors
    )
    {
        this.RootNamespace = rootNamespace;
        this.TaskName = taskName;
        this.BaseResultType = baseResultType;
        this.VisitorInterface = visitorInterface;
        this.AcceptorInterface = acceptorInterface;
        this.AcceptorTypes = acceptors;
    }

    public bool IsAsync => !string.IsNullOrWhiteSpace(this.TaskName);

    public string IfAsync(string str) => this.IsAsync ? str : string.Empty;

    public bool IsGeneric => this.BaseResultType is ITypeParameterSymbol;

    public string GetTypeParamStr()
    {
        var typeParams = this.VisitorInterface.TypeParameters;
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
        var typeParams = this.VisitorInterface.TypeParameters;
        return this.IsGeneric ? typeParams.SkipLast(1) : typeParams;
    }

    private static string _GetArgName(string typeName)
    {
        if (Regex.IsMatch(typeName, "^T[A-Z]")) {
            typeName = typeName.Substring(1);
        }
        return char.ToLower(typeName[0]) + typeName.Substring(1);
    }

    public string GetTypeConstraintList() => this.VisitorInterface
        .ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat.WithGenericsOptions(SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeTypeConstraints))
        .Substring(this.VisitorInterface.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat).Length);

    public string GetBaseInterfaceName(string name)
        => string.IsNullOrWhiteSpace(this.RootNamespace) ? name : $"{this.RootNamespace}.{name}";

    public string GetReturnType(ITypeSymbol? resultType)
    {
        var resultName = resultType?.ToDisplayString();
        var taskName = !this.IsAsync ? null : $"System.Threading.Tasks.{this.TaskName}";
        return resultName is null ? taskName ?? "void" : taskName is null ? resultName : $"{taskName}<{resultName}>";
    }

    public static string WrapAngle(ITypeSymbol type, ITypeSymbol? resultType = null)
        => $"<{type.ToDisplayString()}" + (resultType is null ? ">" : $", {resultType.ToDisplayString()}>");

}
