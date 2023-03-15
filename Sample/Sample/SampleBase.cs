
using VisitorPatternGenerator;

namespace Sample;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public abstract partial class SampleBase { }

[TaskVisitor<SampleBase, int>]
public partial interface ISampleVisitor { }

public partial interface ISample2 { }

[Visitor<ISample2>]
public partial interface ISample2Visitor { }


[Acceptor<SampleBase>]
[Acceptor<ISample2>]
public partial class Sample1 { }

[Acceptor<SampleBase>]
[Acceptor<ISample2>]
public partial class Sample2 { }

[Acceptor<SampleBase>]
public partial class Sample3 { }
