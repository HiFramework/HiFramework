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
    public class SignalComponentTests
    {
        [TestInitialize()]
        public void InitTest()
        {
            Center.Init(new HiFrameworkBinder());
        }

        [TestMethod()]
        public void OnCreatedTest()
        {

        }

        [TestMethod()]
        public void OnDestroyTest()
        {

        }

        [TestMethod()]
        public void GetSignalTest()
        {
            var c = Center.Get<ISignal>();

            bool isTrue = false;
            var signal0 = c.GetSignal<TestSignal0>();
            signal0.AddListener(() => { isTrue = true; });
            signal0.Fire();
            Assert.IsTrue(isTrue);

            int x = 0;
            string y = "hello";
            var signal2 = c.GetSignal<TestSignal2>();
            signal2.AddListener((_, __) => { x = _; y = __; });
            signal2.Fire(100, "world");
            Assert.AreEqual(x, 100);
            Assert.AreEqual(y, "world");

        }

        [TestMethod()]
        public void RemoveSignalTest()
        {
            var c = Center.Get<ISignal>();

            c.GetSignal<TestSignal0>();
            c.RemoveSignal<TestSignal0>();
        }

        [TestCleanup]
        public void DisposeTest()
        {

        }

        private class TestSignal0 : Signal
        {

        }

        private class TestSignal2 : Signal<int, string>
        {

        }
    }
}