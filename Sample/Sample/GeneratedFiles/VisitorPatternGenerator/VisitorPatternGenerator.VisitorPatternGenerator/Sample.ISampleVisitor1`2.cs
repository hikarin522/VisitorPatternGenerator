﻿// <auto-generated/>

namespace Sample
{
partial interface ISample
{
    TResult Accept<TArg1, TResult>(Sample.ISampleVisitor1<TArg1, TResult> visitor, TArg1 arg1);
}
}

namespace Sample
{
partial interface ISampleVisitor1<in TArg1, out TResult>
{
    TResult Visit(Sample.Sample1 value, TArg1 arg1);
    TResult Visit(Sample.Sample2 value, TArg1 arg1);
    TResult Visit(Sample.Sample3 value, TArg1 arg1);
    TResult Visit(Sample.Sample4 value, TArg1 arg1);
}
}

namespace Sample
{
partial class Sample1: Sample.ISample
{
    TResult Sample.ISample.Accept<TArg1, TResult>(Sample.ISampleVisitor1<TArg1, TResult> visitor, TArg1 arg1) => visitor.Visit(this, arg1);
}
}

namespace Sample
{
partial class Sample2: Sample.ISample
{
    TResult Sample.ISample.Accept<TArg1, TResult>(Sample.ISampleVisitor1<TArg1, TResult> visitor, TArg1 arg1) => visitor.Visit(this, arg1);
}
}

namespace Sample
{
partial class Sample3: Sample.ISample
{
    TResult Sample.ISample.Accept<TArg1, TResult>(Sample.ISampleVisitor1<TArg1, TResult> visitor, TArg1 arg1) => visitor.Visit(this, arg1);
}
}

namespace Sample
{
partial class Sample4: Sample.ISample
{
    TResult Sample.ISample.Accept<TArg1, TResult>(Sample.ISampleVisitor1<TArg1, TResult> visitor, TArg1 arg1) => visitor.Visit(this, arg1);
}
}