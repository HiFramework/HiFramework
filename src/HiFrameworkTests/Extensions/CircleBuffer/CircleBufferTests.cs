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
    public class CircleBufferTests
    {
        [TestMethod()]
        public void CircleBufferTest()
        {
            new CircleBuffer<byte>();
        }

        [TestMethod()]
        public void MoveReadPostionTest()
        {
            var c = new CircleBuffer<byte>(1000);
            c.Read(50);
            c.MoveReadPostion(50);
            Assert.AreEqual(c.ReadPosition, 100);
        }

        [TestMethod()]
        public void MoveWritePositionTest()
        {
            var c = new CircleBuffer<byte>(1000);
            c.Write(new byte[50]);
            c.MoveWritePosition(50);
            Assert.AreEqual(c.WritePosition, 100);
        }

        [TestMethod()]
        public void MoveReadPositionToTest()
        {
            var c = new CircleBuffer<byte>(1000);
            c.MoveReadPositionTo(100);
            Assert.AreEqual(c.ReadPosition, 100);
        }

        [TestMethod()]
        public void MoveWritePostionToTest()
        {
            var c = new CircleBuffer<byte>(1000);
            c.MoveWritePostionTo(100);
            Assert.AreEqual(c.WritePosition, 100);
        }

        [TestMethod()]
        public void ReadTest()
        {
            var c = new CircleBuffer<byte>(10);
            var data = c.Read(20);
            Assert.AreEqual(data.Length, 20);
        }

        [TestMethod()]
        public void ReadTest1()
        {
        }

        [TestMethod()]
        public void WriteTest()
        {
        }

        [TestMethod()]
        public void WriteTest1()
        {
        }

        [TestMethod()]
        public void DisposeTest()
        {
            var c = new CircleBuffer<byte>(10);
            c.Dispose();
        }
    }
}