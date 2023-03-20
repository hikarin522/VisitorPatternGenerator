﻿// <auto-generated/>

namespace Sample.SampleRequest
{
partial interface ISampleRequest
{
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2);
}
}

namespace Sample.SampleRequest
{
partial interface ISampleRequestVisitor2<in TArg1, in TArg2>
{
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> VisitAsync(Sample.SampleRequest.SampleRequest5 value, TArg1 arg1, TArg2 arg2);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> VisitAsync(Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.ISampleResponse> value, TArg1 arg1, TArg2 arg2);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse1> VisitAsync(Sample.SampleRequest.SampleRequest1 value, TArg1 arg1, TArg2 arg2);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse2> VisitAsync(Sample.SampleRequest.SampleRequest2 value, TArg1 arg1, TArg2 arg2);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse3> VisitAsync(Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.SampleResponse3> value, TArg1 arg1, TArg2 arg2);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest5: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2) => await visitor.VisitAsync(this, arg1, arg2);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest4: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2) => await visitor.VisitAsync((Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.ISampleResponse>)this, arg1, arg2);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest1: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync(this, arg1, arg2);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest2: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync(this, arg1, arg2);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest3: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync<TArg1, TArg2>(Sample.SampleRequest.ISampleRequestVisitor2<TArg1, TArg2> visitor, TArg1 arg1, TArg2 arg2) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync((Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.SampleResponse3>)this, arg1, arg2);
}
}
