﻿// <auto-generated/>

namespace Sample
{
partial interface ISample
{
    System.Threading.Tasks.Task<TResult> AcceptAsync<TResult>(Sample.ISampleTaskVisitor<TResult> visitor);
}
}

namespace Sample
{
partial interface ISampleTaskVisitor<TResult>
{
    System.Threading.Tasks.Task<TResult> VisitAsync(Sample.Sample1 value);
    System.Threading.Tasks.Task<TResult> VisitAsync(Sample.Sample2 value);
    System.Threading.Tasks.Task<TResult> VisitAsync(Sample.Sample3 value);
    System.Threading.Tasks.Task<TResult> VisitAsync(Sample.Sample4 value);
}
}

namespace Sample
{
partial class Sample1: Sample.ISample
{
    async System.Threading.Tasks.Task<TResult> Sample.ISample.AcceptAsync<TResult>(Sample.ISampleTaskVisitor<TResult> visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample
{
partial class Sample2: Sample.ISample
{
    async System.Threading.Tasks.Task<TResult> Sample.ISample.AcceptAsync<TResult>(Sample.ISampleTaskVisitor<TResult> visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample
{
partial class Sample3: Sample.ISample
{
    async System.Threading.Tasks.Task<TResult> Sample.ISample.AcceptAsync<TResult>(Sample.ISampleTaskVisitor<TResult> visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample
{
partial class Sample4: Sample.ISample
{
    async System.Threading.Tasks.Task<TResult> Sample.ISample.AcceptAsync<TResult>(Sample.ISampleTaskVisitor<TResult> visitor) => await visitor.VisitAsync(this);
}
}