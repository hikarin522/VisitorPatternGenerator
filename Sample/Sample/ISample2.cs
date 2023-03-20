
using VisitorPatternGenerator;

namespace Sample;

public partial interface ISample2 { }

[Acceptor(AcceptorOptions.MessagePackUnion)]
public abstract partial class SampleBase { }

[Acceptor<ISample2>]
[Acceptor<SampleBase>]
public partial class Sample1 { }

[Acceptor<ISample2>]
[Acceptor<SampleBase>]
public partial class Sample2 { }

[Acceptor<SampleBase>]
public partial class Sample3 { }

[Visitor<ISample2>]
public partial interface ISample2Visitor { }

[Visitor<ISample2>]
public partial interface ISample2Visitor1<in TArg1, out TResult> where TArg1: class, new() where TResult: struct { }

[TaskVisitor<SampleBase, int>]
public partial interface ISampleBaseVisitor { }
