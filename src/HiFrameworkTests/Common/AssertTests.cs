using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFrameworkTests
{
    [TestClass()]
    public class AssertTests
    {
        [TestMethod()]
        public void IsTrueTest()
        {
#if DEBUG
            bool isTrue = false;
            try
            {
                AssertThat.IsTrue(false);
            }
            catch (Exception e)
            {
                isTrue = true;
            }
            Assert.IsTrue(isTrue);
#endif
        }
    }
}