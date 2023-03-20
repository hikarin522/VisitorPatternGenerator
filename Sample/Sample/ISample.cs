
using VisitorPatternGenerator;

namespace Sample;

public partial interface ISample { }

[Acceptor<ISample>]
public partial class Sample1 { }

[Acceptor<ISample>]
public partial class Sample2 { }

[Acceptor<ISample>]
public partial class Sample3 { }

[Acceptor<ISample>]
public partial class Sample4 { }

[Visitor<ISample>]
public partial interface ISampleVisitor { }

[Visitor<ISample>]
public partial interface ISampleVisitor<out TResult> { }

[Visitor<ISample>]
public partial interface ISampleVisitor1<in TArg1, out TResult> { }

[Visitor<ISample>]
public partial interface ISampleVisitor2<in TArg1, in TArg2, out TResult> { }

[Visitor<ISample>]
public partial interface ISampleVisitor3<in TArg1, in TArg2, in TArg3, out TResult> { }

[Visitor<ISample>(true)]
public partial interface ISampleVisitor1<in TArg1> { }

[Visitor<ISample>(true)]
public partial interface ISampleVisitor2<in TArg1, in TArg2> { }

[Visitor<ISample>(true)]
public partial interface ISampleVisitor3<in TArg1, in TArg2, in TArg3> { }

[TaskVisitor<ISample>]
public partial interface ISampleTaskVisitor { }

[TaskVisitor<ISample>]
public partial interface ISampleTaskVisitor<TResult> { }

[TaskVisitor<ISample>]
public partial interface ISampleTaskVisitor1<in TArg1, TResult> { }

[TaskVisitor<ISample>]
public partial interface ISampleTaskVisitor2<in TArg1, in TArg2, TResult> { }

[TaskVisitor<ISample>]
public partial interface ISampleTaskVisitor3<in TArg1, in TArg2, in TArg3, TResult> { }

[TaskVisitor<ISample>(true)]
public partial interface ISampleTaskVisitor1<in TArg1> { }

[TaskVisitor<ISample>(true)]
public partial interface ISampleTaskVisitor2<in TArg1, in TArg2> { }

[TaskVisitor<ISample>(true)]
public partial interface ISampleTaskVisitor3<in TArg1, in TArg2, in TArg3> { }

[ValueTaskVisitor<ISample>]
public partial interface ISampleValueTaskVisitor { }

[ValueTaskVisitor<ISample>]
public partial interface ISampleValueTaskVisitor<TResult> { }

[ValueTaskVisitor<ISample>]
public partial interface ISampleValueTaskVisitor1<in TArg1, TResult> { }

[ValueTaskVisitor<ISample>]
public partial interface ISampleValueTaskVisitor2<in TArg1, in TArg2, TResult> { }

[ValueTaskVisitor<ISample>]
public partial interface ISampleValueTaskVisitor3<in TArg1, in TArg2, in TArg3, TResult> { }

[ValueTaskVisitor<ISample>(true)]
public partial interface ISampleValueTaskVisitor1<in TArg1> { }

[ValueTaskVisitor<ISample>(true)]
public partial interface ISampleValueTaskVisitor2<in TArg1, in TArg2> { }

[ValueTaskVisitor<ISample>(true)]
public partial interface ISampleValueTaskVisitor3<in TArg1, in TArg2, in TArg3> { }
