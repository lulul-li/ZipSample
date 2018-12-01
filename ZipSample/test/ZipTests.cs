using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_3_girls_and_5_boys()
        {
            var girls = Repository.Get3Girls();
            var keys = Repository.Get5Keys();

            var girlAndBoyPairs = MyZip(girls, keys, (g, k) =>Tuple.Create(g.Name,k.OwnerBoy.Name)).ToList();
            var expected = new List<Tuple<string, string>>
            {
                Tuple.Create("Jean", "Joey"),
                Tuple.Create("Mary", "Frank"),
                Tuple.Create("Karen", "Bob"),
            };

            expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
        }


        private IEnumerable<TResult> MyZip<TSoucre1,TSource2,TResult>(IEnumerable<TSoucre1> source1, IEnumerable<TSource2> source2,Func<TSoucre1, TSource2, TResult> selector)
        {
            var girlsEnumerator = source1.GetEnumerator();
            var keyEnumerator = source2.GetEnumerator();

            while (girlsEnumerator.MoveNext() && keyEnumerator.MoveNext())
            {
                yield return selector(girlsEnumerator.Current,keyEnumerator.Current);
            }
        }
    }
}