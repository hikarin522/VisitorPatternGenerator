
using Sample.SampleResponse;

using VisitorPatternGenerator;

namespace Sample.SampleRequest;

[Acceptor(AcceptorOptions.MessagePackUnion)]
public partial interface ISampleRequest { }

[ValueTaskVisitor<ISampleRequest, ISampleResponse>]
public partial interface ISampleRequestVisitor { }

[ValueTaskVisitor<ISampleRequest>]
public partial interface ISampleRequestVisitor2<in TArg1, in TArg2, in TArg3, TResult> { }

[Visitor<ISampleRequest>]
public partial interface ISampleRequestVisitor3<in T1, in T2, out TResult> where T1 : class, new() where T2 : struct { }

[TaskVisitor<ISampleRequest>(true)]
public partial interface ISampleRequestVisitor4<in TArg1, in TArg2> { }

[Acceptor<ISampleRequest, Sample1Response>]
public partial class Sample1Request { }

[Acceptor<ISampleRequest, Sample2Response>]
public partial class Sample2Request { }

[Acceptor<ISampleRequest>]
public partial class Sample3Request { }
