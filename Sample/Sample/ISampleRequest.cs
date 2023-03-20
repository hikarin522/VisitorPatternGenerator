
using Sample.SampleResponse;

using VisitorPatternGenerator;

namespace Sample.SampleRequest;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleRequest { }

[Acceptor<ISampleRequest, Sample1Response>]
public partial class Sample1Request { }

[Acceptor<ISampleRequest, Sample2Response>]
public partial class Sample2Request { }

[Acceptor<ISampleRequest>]
public partial class Sample3Request { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor1<in TArg1> { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor2<in TArg1, in TArg2> { }
