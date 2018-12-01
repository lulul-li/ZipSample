﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void reverse_string()
        {
            var source = new[] { "Apple", "Banana", "Cat" };

            var actual = MyReverse(source).ToList();
            var expected = new List<string> { "Cat", "Banana", "Apple" };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<string> MyReverse(IEnumerable<string> source)
        {
            return new Stack<string>(source);
            //var result =source.ToArray()
            //for (int i = result.Count-1; i >=0; i--)
            //{
            //    yield return result[i];
            //}
        }
    }
}