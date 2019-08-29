using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiFramework.Tests
{
    [TestClass]
    public class HiFloatTest
    {
        [TestMethod]
        public void TestFloat()
        {
            HiFloat.Length = 3;
            HiFloat x = 1;
            HiFloat y = 1.0f;
            HiFloat z = 1.12345f;

            Assert.AreEqual(x, 1);
            Assert.AreEqual(y, 1);
            Assert.AreEqual(z, 1.123f);
        }
    }
}
