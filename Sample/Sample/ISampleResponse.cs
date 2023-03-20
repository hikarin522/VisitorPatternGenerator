
using VisitorPatternGenerator;

namespace Sample.SampleResponse;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleResponse { }

[Acceptor<ISampleResponse>]
public partial class SampleResponse1 { }

[Acceptor<ISampleResponse>]
public partial class SampleResponse2 { }

[Acceptor<ISampleResponse>]
public partial class SampleResponse3 { }

[Acceptor<ISampleResponse>]
public partial class SampleResponse4 { }

[Visitor<ISampleResponse>]
public partial interface ISampleResponseVisitor { }
