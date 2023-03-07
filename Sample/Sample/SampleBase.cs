
using VisitorPatternGenerator;

namespace Sample;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public abstract partial class SampleBase { }

[TaskVisitor<SampleBase, int>]
public partial interface ISampleVisitor { }


[Acceptor<SampleBase>]
public partial class Sample1 { }

[Acceptor<SampleBase>]
public partial class Sample2 { }
