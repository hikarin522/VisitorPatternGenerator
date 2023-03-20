
using VisitorPatternGenerator;

namespace Sample.SampleResponse;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleResponse { }

[Acceptor<ISampleResponse>]
public partial class Sample1Response { }

[Acceptor<ISampleResponse>]
public partial class Sample2Response { }

[Visitor<ISampleResponse>]
public partial interface ISampleResponseVisitor { }
