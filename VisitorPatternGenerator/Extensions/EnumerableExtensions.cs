using System.Collections.Generic;

namespace System.Linq;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> @this, int count)
        => @this.Skip(@this.Count() - count);

    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> @this, int count)
        => @this.Take(@this.Count() - count);
}

internal static class StringExtensions
{
    public static string Take(this string @this, int count)
        => @this.Substring(0, count);

    public static string Skip(this string @this, int count)
        => @this.Substring(count);

    public static string TakeLast(this string @this, int count)
        => @this.Substring(@this.Length - count);

    public static string SkipLast(this string @this, int count)
        => @this.Substring(0, @this.Length - count);
}
