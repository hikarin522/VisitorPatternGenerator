
namespace VisitorPatternGenerator.Templates;

partial class InterfacesTemplate
{
    public string RootNamespace { get; }

    public bool NonPublic { get; }

    public InterfacesTemplate(string rootNamespace, bool nonPublic)
    {
        this.RootNamespace = rootNamespace;
        this.NonPublic = nonPublic;
    }

    public string Accessibility => this.NonPublic ? string.Empty : "public ";
}
