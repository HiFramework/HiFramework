using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace HiFramework.Tests
{
    [TestClass()]
    public class LogTests
    {
        [TestMethod]
        public void TestInit()
        {
            Log.LogHandler = new Logger();
            Assert.IsNotNull(Log.LogHandler);
            Assert.IsTrue(Log.LogHandler is Logger);
        }

        [TestMethod]
        public void TestEvent()
        {
            Log.LogHandler = new Logger();
            string info = string.Empty;
            Log.OnInfo += ((sender, y) => { info = y[0].ToString(); });
            Log.Info("info");
            Assert.AreEqual(info, "info");
        }

        [TestMethod]
        public void TestParam()
        {
            string info = Log.GetFormat("info");
            Assert.AreEqual(info, "[info]");
        }

        class Logger : ILogHandler
        {
            public event Action<string> OnInfo;
            public event Action<string> OnWarning;
            public event Action<string> OnError;

            public void Info(params object[] args)
            {

            }

            public void Warning(params object[] args)
            {
            }

            public void Error(params object[] args)
            {
            }
        }
    }
}