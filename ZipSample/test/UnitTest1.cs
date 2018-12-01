using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ZipSample.test
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(106, "2", true)]
        [TestCase(106, "11", true)]
        [TestCase(106, "0", false)]
        [TestCase(106, "12", false)]
        [TestCase(106, "99", true)]
        [TestCase(107, "2a", true)]
        [TestCase(107, "2b", true)]
        [TestCase(107, "14", true)]
        [TestCase(107, "1", true)]
        [TestCase(107, "2", false)]
        [TestCase(107, "12", false)]
        [TestCase(107, "99", true)]
        [TestCase(107, "abc", false)]
        public void valid_list(int year, string content, bool expected)
        {
            var medical = new Medical(year, content);
            Assert.AreEqual(expected, medical.IsValid());
        }
    }

    public class Medical
    {
        public int Year { get; }
        public string Content { get; }

        public Medical(int year, string content)
        {
            Year = year;
            Content = content;
        }

        public bool IsValid()
        {
            var dictionary = new Dictionary<int, Func<string, bool>>
            {
                {106, Valid106Content},
                {107, Valid107Content}
            };
            return dictionary.ContainsKey(Year) && dictionary[Year](Content);
        }


        private bool Valid107Content(string c)
        {
            var list = Enumerable.Range(1, 14).Except(new[] { 2, 12 }).Select(x => x.ToString()).ToList();
            list.AddRange(new[] { "99", "2a", "2b" });
            return list.Contains(c);
        }

        private static bool Valid106Content(string content)
        {
            if (int.TryParse(content, out var number))
            {
                if ((number >= 1 && number <= 11) || number == 99)
                {
                    return true;
                }
            }

            return false;
        }

        private bool NumberNotContain(string content)
        {
            if (Int32.TryParse(content, out var number))
            {
                if (number != 2 && number != 12)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumber(string c, int i, int i1)
        {
            if (Int32.TryParse(c, out var content))
            {
                if (content >= i && content <= i1)
                {
                    return true;
                }
            }

            return false;
        }


    }
}