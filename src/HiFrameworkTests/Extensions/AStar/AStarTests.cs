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
    public class AStarTests
    {
        [TestMethod()]
        public void FindTest()
        {
            /// ***
            /// *
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();

            node1.SurroundNodes.Add(node2);
            node1.SurroundNodes.Add(node4);
            node2.SurroundNodes.Add(node1);
            node2.SurroundNodes.Add(node3);
            node3.SurroundNodes.Add(node2);
            node4.SurroundNodes.Add(node1);
            var path = AStar.Find(node4, node3);
            Assert.AreEqual(path.Count, 4);
        }

        [TestMethod()]
        public void FindAsyncTest()
        {
            /// ***
            /// *
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();

            node1.SurroundNodes.Add(node2);
            node1.SurroundNodes.Add(node4);
            node2.SurroundNodes.Add(node1);
            node2.SurroundNodes.Add(node3);
            node3.SurroundNodes.Add(node2);
            node4.SurroundNodes.Add(node1);
            AStar.Find(node4, node3, (x) => { });
        }
    }
}