using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiFramework.Tests
{
    [TestClass()]
    public class InjectComponentTests
    {
        [TestInitialize]
        public void Init()
        {
            Center.Init(new HiFrameworkBinder());
        }

        [TestCleanup]
        public void Dispose()
        {
            Center.Dispose();
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
        public void BindTest()
        {
            var c = Center.Get<IInject>();
            var test = new TestClass1();
            c.Bind<TestClass1>().To(test);
            c.Bind<int>().To(10);
            c.Inject<TestClass1>();
            Assert.AreEqual(test.x, 10);
            Assert.AreEqual(test.GetY(), 10);
        }

        [TestMethod()]
        public void InjectTest()
        {
            var c = Center.Get<IInject>();
            var test = new TestClass2();
            c.Bind<TestClass2>().To(test).AsName("class");
            c.Bind<int>().To(10).AsName("x");
            c.Bind<int>().To(20).AsName("y");
            c.Inject(typeof(TestClass2), "class");
            Assert.AreEqual(test.x, 10);
            Assert.AreEqual(test.GetY(), 20);

        }

        private class TestClass1
        {
            [Inject]
            public int x;

            [Inject]
            private int y;

            public int GetY()
            {
                return y;
            }
        }

        public class TestClass2
        {
            [Inject("x")]
            public int x;

            [Inject("y")]
            public int y;

            public int GetY()
            {
                return y;
            }
        }
    }
}