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
    public class AssertTests
    {
        [TestMethod()]
        public void IsTrueTest()
        {
#if DEBUG
            bool isTrue = false;
            try
            {
                HiFramework.Assert.IsTrue(isTrue);
            }
            catch (Exception e)
            {
                isTrue = true;
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(isTrue);
#endif
        }
    }
}