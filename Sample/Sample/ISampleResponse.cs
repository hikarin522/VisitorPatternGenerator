
using VisitorPatternGenerator;

namespace Sample.SampleResponse;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleResponse { }

[Visitor<ISampleResponse>]
public partial interface ISampleResponseVisitor { }

[Acceptor<ISampleResponse>]
public partial class Sample1Response { }

[Acceptor<ISampleResponse>]
public partial class Sample2Response { }
