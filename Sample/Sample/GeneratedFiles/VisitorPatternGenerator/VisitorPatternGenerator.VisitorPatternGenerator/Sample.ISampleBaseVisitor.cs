﻿// <auto-generated/>

namespace Sample
{
partial class SampleBase
{
    public abstract System.Threading.Tasks.Task<int> AcceptAsync(Sample.ISampleBaseVisitor visitor);
}
}

namespace Sample
{
partial interface ISampleBaseVisitor
{
    System.Threading.Tasks.Task<int> VisitAsync(Sample.Sample1 value);
    System.Threading.Tasks.Task<int> VisitAsync(Sample.Sample2 value);
    System.Threading.Tasks.Task<int> VisitAsync(Sample.Sample3 value);
}
}

namespace Sample
{
partial class Sample1: Sample.SampleBase
{
    public sealed override async System.Threading.Tasks.Task<int> AcceptAsync(Sample.ISampleBaseVisitor visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample
{
partial class Sample2: Sample.SampleBase
{
    public sealed override async System.Threading.Tasks.Task<int> AcceptAsync(Sample.ISampleBaseVisitor visitor) => await visitor.VisitAsync(this);
}
}

namespace Sample
{
partial class Sample3: Sample.SampleBase
{
    public sealed override async System.Threading.Tasks.Task<int> AcceptAsync(Sample.ISampleBaseVisitor visitor) => await visitor.VisitAsync(this);
}
}
