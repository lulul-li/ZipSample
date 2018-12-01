using System;
using System.Collections.Generic;
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
            if (Year != 106 && Year != 107)
            {
                return false;
            }

            if (Content=="99")
            {
                return true;
            }

            //new Dictionary<int,Func<string,bool>>
            //{
            //    { 106,(c)=> c=="2a"||c=="2b"},
            //}
            if (Year==106)
            {
                var content = Convert.ToInt32(Content);
                if (content>=1  && content<=11)
                {
                    return true;
                }
            }
            if (Year == 107)
            {
                if (Content=="2a"||Content=="2b")
                {
                    return true;
                }
                if (Int32.TryParse(Content, out var content))
                {
                    if ((content >= 1 || content <= 14) && (content != 2 && content != 12))
                    {
                        return true;
                    }
                }

               
            }
            return false;
        }
    }
}