using System.Collections.Generic;

namespace ZipSample.test
{
    public static class LuluLinq
    {
        public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
          

            while (firstEnumerator.MoveNext())
            {
                yield return firstEnumerator.Current;
            }
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }

            
        }
    }
}