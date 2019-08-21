using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiFramework.Test
{
    [TestClass]
    public class BlockBufferTest
    {
        [TestMethod]
        public void WriteSmall()
        {
            var buffer = new BlockBuffer<byte>();
            var bytes = new byte[100];
            buffer.Write(bytes);
            Assert.AreEqual(buffer.WritePosition, 100);
            Assert.AreEqual(buffer.ReadPosition, 0);
        }

        [TestMethod]
        public void WriteHuge()
        {
            byte[] bytes = new byte[2000];
            var buffer = new BlockBuffer<byte>();
            buffer.Write(bytes);
            Assert.AreEqual(buffer.WritePosition, bytes.Length);
            Assert.AreEqual(buffer.ReadPosition, 0);
            Assert.IsTrue(buffer.Size >= bytes.Length);
        }

        [TestMethod]
        public void Read()
        {
            var buffer = new BlockBuffer<byte>();
            var buffer2 = new BlockBuffer<int>();
            var bytes = new byte[100];
            buffer.Write(bytes);
            buffer.Read(50);
            Assert.AreEqual(buffer.WritePosition, 100);
            Assert.AreEqual(buffer.ReadPosition, 50);
        }

        [TestMethod]
        public void Index()
        {
            var buffer = new BlockBuffer<byte>(100);
            var bytes = new byte[100];
            buffer.Write(bytes);
            buffer.Read(50);
            buffer.ResetIndex();
            Assert.AreEqual(buffer.WritePosition, 50);
            Assert.AreEqual(buffer.ReadPosition, 0);
        }
    }
}
