﻿// <auto-generated/>

namespace Sample.SampleRequest
{
partial interface ISampleRequest
{
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor);
}
}

namespace Sample.SampleRequest
{
partial interface ISampleRequestVisitor
{
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> VisitAsync(Sample.SampleRequest.SampleRequest5 value);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> VisitAsync(Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.ISampleResponse> value);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse1> VisitAsync(Sample.SampleRequest.SampleRequest1 value);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse2> VisitAsync(Sample.SampleRequest.SampleRequest2 value);
    System.Threading.Tasks.ValueTask<Sample.SampleResponse.SampleResponse3> VisitAsync(Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.SampleResponse3> value);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest5: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest4: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor) => await visitor.VisitAsync((Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.ISampleResponse>)this);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest1: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync(this);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest2: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync(this);
}
}

namespace Sample.SampleRequest
{
partial class SampleRequest3: Sample.SampleRequest.ISampleRequest
{
    async System.Threading.Tasks.ValueTask<Sample.SampleResponse.ISampleResponse> Sample.SampleRequest.ISampleRequest.AcceptAsync(Sample.SampleRequest.ISampleRequestVisitor visitor) => (Sample.SampleResponse.ISampleResponse)await visitor.VisitAsync((Sample.SampleRequest.ISampleRequest<Sample.SampleResponse.SampleResponse3>)this);
}
}
