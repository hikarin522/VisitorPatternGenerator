
namespace System.Collections.Generic;

internal static class KeyValuePairExtensions
{
    public static void Deconstruct<TKey, TValue>(this in KeyValuePair<TKey, TValue> @this, out TKey key, out TValue value)
        => (key, value) = (@this.Key, @this.Value);
}
