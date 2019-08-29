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
    public class PoolTests
    {
        [TestMethod()]
        public void GetObjectFromPoolTest()
        {
            var pool = new Pool<OneObject>(new ObjectHandler());
            var obj = pool.GetObjectFromPool();
            Assert.AreEqual(obj.x, 10);
            Assert.AreEqual(pool.Count, 0);
            pool.RecleimObjectToPool(obj);
            Assert.AreEqual(pool.Count, 1);
        }

        [TestMethod()]
        public void RecleimObjectToPoolTest()
        {
            var pool = new Pool<OneObject>(new ObjectHandler());
            var obj = pool.GetObjectFromPool();
            pool.RecleimObjectToPool(obj);
        }

        [TestMethod()]
        public void DisposeTest()
        {

        }

        private class ObjectHandler : IPoolObjectHanlder<OneObject>
        {
            public OneObject OnObjectCreated()
            {
                var o = new OneObject
                {
                    x = 10
                };
                return o;
            }

            public void OnObjectDestroy(OneObject o)
            {
                o.x = 0;
            }

            public void OnObjectInPool(OneObject o)
            {
                o.x = 0;
            }

            public void OnObjectOutPool(OneObject o)
            {
                o.x = 10;
            }
        }

        private class OneObject
        {
            public int x;
        }
    }
}