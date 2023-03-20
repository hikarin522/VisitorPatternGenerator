
using Sample.SampleResponse;

using VisitorPatternGenerator;

namespace Sample.SampleRequest;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleRequest { }

public partial interface ISampleRequest<T>: ISampleRequest where T : ISampleResponse { }

[Acceptor<ISampleRequest, SampleRequest1, SampleResponse1>]
public partial class SampleRequest1 { }

[Acceptor<ISampleRequest, SampleRequest2, SampleResponse2>]
public partial class SampleRequest2 { }

[Acceptor<ISampleRequest, ISampleRequest<SampleResponse3>, SampleResponse3>]
public partial class SampleRequest3: ISampleRequest<SampleResponse3> { }

[Acceptor<ISampleRequest, ISampleRequest<ISampleResponse>>]
public partial class SampleRequest4: ISampleRequest<ISampleResponse> { }

[Acceptor<ISampleRequest>]
public partial class SampleRequest5 { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor1<in TArg1> { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor2<in TArg1, in TArg2> { }
