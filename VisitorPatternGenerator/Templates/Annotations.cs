namespace VisitorPatternGenerator;

[System.Flags]
internal enum AcceptorOptions
{
    None = 0,
    MessagePackUnion = 0x100,
}

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class AcceptorAttribute: System.Attribute
{
    public AcceptorOptions Options { get; }

    public AcceptorAttribute(AcceptorOptions options = AcceptorOptions.None) { this.Options = options; }
}

[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class AcceptorAttribute<TAcceptor>: System.Attribute where TAcceptor : class { }

[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class AcceptorAttribute<TAcceptor, TResult>: System.Attribute where TAcceptor : class { }

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class VisitorAttribute<TAcceptor>: System.Attribute where TAcceptor : class
{
    public bool VoidReturn { get; }

    public VisitorAttribute(bool voidReturn = false) { this.VoidReturn = voidReturn; }
}

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class VisitorAttribute<TAcceptor, TResult>: System.Attribute where TAcceptor : class { }

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class TaskVisitorAttribute<TAcceptor>: System.Attribute where TAcceptor : class
{
    public bool VoidReturn { get; }

    public TaskVisitorAttribute(bool voidReturn = false) { this.VoidReturn = voidReturn; }
}

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class TaskVisitorAttribute<TAcceptor, TResult>: System.Attribute where TAcceptor : class { }

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class ValueTaskVisitorAttribute<TAcceptor>: System.Attribute where TAcceptor : class
{
    public bool VoidReturn { get; }

    public ValueTaskVisitorAttribute(bool voidReturn = false) { this.VoidReturn = voidReturn; }
}

[System.AttributeUsage(System.AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
internal sealed class ValueTaskVisitorAttribute<TAcceptor, TResult>: System.Attribute where TAcceptor : class { }
