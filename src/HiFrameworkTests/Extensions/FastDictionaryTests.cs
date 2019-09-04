using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFramework.Tests
{
    [TestClass()]
    public class FastDictionaryTests
    {
        [TestMethod()]
        public void FastDictionaryTest()
        {
            FastDictionary<int, string> test1 = new FastDictionary<int, string>();
            test1[1] = "1";
            test1[2] = "2";

            string test = test1[1];


            Assert.AreEqual(test1[1], "1");
        }
    }
}