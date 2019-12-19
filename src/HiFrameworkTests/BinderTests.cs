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
    public class BinderTests
    {
        [TestMethod]
        public void InitTest()
        {
            Center.Init(new HiFrameworkBinder());
        }
    }
}