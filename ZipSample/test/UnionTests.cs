using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_integers()
        {
            var first = new List<int> { 1, 3, 3, 5 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 3, 5, 7, 9 };

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Union_Girls()
        {
            var first = new List<Girl>
            {
                new Girl()
                {
                    Name = "lulu",
                    Age = 18
                },
                new Girl()
                {
                    Name = "lily",
                    Age = 17
                }
            };
            var second = new List<Girl>
            {
                new Girl()
                {
                    Name = "leo",
                    Age = 28
                },
                new Girl()
                {
                    Name = "lulu",
                    Age = 18
                }
            };
            var expected = new List<Girl>()
            {
                new Girl()
                {
                    Name = "lulu",
                    Age = 18
                },
                new Girl()
                {
                    Name = "lily",
                    Age = 17
                },
                new Girl()
                {
                    Name = "leo",
                    Age = 28
                },
            };

            var actual = MyUnion(first, second, new MyCompare()).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private static IEnumerable<TSource> MyUnion<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> myCompare)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            var hashSet = new HashSet<TSource>(myCompare);
            while (firstEnumerator.MoveNext())
            {
                if (hashSet.Add(firstEnumerator.Current))
                {
                    yield return firstEnumerator.Current;
                }
            }
            while (secondEnumerator.MoveNext())
            {
                if (hashSet.Add(secondEnumerator.Current))
                {
                    yield return secondEnumerator.Current;
                }
            }
        }

        private IEnumerable<TSource> MyUnion<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return MyUnion<TSource>(first, second, EqualityComparer<TSource>.Default);
            //var firstEnumerator = first.GetEnumerator();
            //var secondEnumerator = second.GetEnumerator();
            //var hashSet = new HashSet<TSource>();
            //while (firstEnumerator.MoveNext())
            //{
            //    if (hashSet.Add(firstEnumerator.Current))
            //    {
            //        yield return firstEnumerator.Current;
            //    }
            //}
            //while (secondEnumerator.MoveNext())
            //{
            //    if (hashSet.Add(secondEnumerator.Current))
            //    {
            //        yield return secondEnumerator.Current;
            //    }
            //}

        }
    }

    public class MyCompare : IEqualityComparer<Girl>
    {
        public bool Equals(Girl x, Girl y)
        {
            return x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode(Girl obj)
        {
            return obj.Age.GetHashCode();
            //匿名型別.get hash code 值相同 hash code就一樣
            //Tuple
        }
    }
}