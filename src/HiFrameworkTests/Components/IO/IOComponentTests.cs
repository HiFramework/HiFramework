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
    public class IOComponentTests
    {
        [TestInitialize]
        public void Init()
        {
            Center.Init(new HiFrameworkBinder());
        }

        [TestCleanup]
        public void Displose()
        {
            Center.Dispose();
        }

        [TestMethod()]
        public void DirectoryCopyTest()
        {
            
        }

        [TestMethod()]
        public void ReadFileTest()
        {

        }

        [TestMethod()]
        public void ReadFileAsyncTest()
        {

        }

        [TestMethod()]
        public void WriteFileTest()
        {

        }

        [TestMethod()]
        public void WriteFileAsyncTest()
        {
            
        }

        [TestMethod()]
        public void OnCreatedTest()
        {
            
        }

        [TestMethod()]
        public void OnDestroyTest()
        {
            
        }
    }
}