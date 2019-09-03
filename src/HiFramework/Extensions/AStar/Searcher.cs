/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    /// <summary>
    /// Because of the diffrent project rule, user should fullfill the position and node define by themselives
    /// </summary>
    internal class Searcher
    {
        /// <summary>
        /// 
        /// </summary>
        private int _maxNodeCount;

        /// <summary>
        /// 
        /// </summary>
        private Node _startNode;

        /// <summary>
        /// 
        /// </summary>
        private Node _endNode;

        /// <summary>
        /// 
        /// </summary>
        private List<Node> _openList = new List<Node>();

        /// <summary>
        /// 
        /// </summary>
        private List<Node> _closeList = new List<Node>();

        private List<Node> _path = new List<Node>();

        /// <summary>
        /// Total searce current now
        /// </summary>
        private int _counter = 0;

        public Searcher(int maxNodeCount)
        {
            this._maxNodeCount = maxNodeCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Node> Find(Node start, Node end)
        {
            _startNode = start;
            _endNode = end;
            _openList.Add(start);
            Recursion();
            return _path;
        }

        /// <summary>
        /// Find path async
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="onFinish"></param>
        public void Find(Node start, Node end, Action<List<Node>> onFinish)
        {
            Find(start, end);
            onFinish.Invoke(_path);
        }

        private void Recursion()
        {
            List<Node> tempNeedAddNodes = new List<Node>();
            for (int i = 0; i < _openList.Count; i++)
            {
                var currentNode = _openList[i];
                if (currentNode == _endNode)
                {
                    Success(currentNode);
                    break;
                }
                for (int j = 0; j < currentNode.SurroundNodes.Count; j++)
                {
                    _counter++;
                    if (_counter <= _maxNodeCount)
                    {
                        var nextNode = currentNode.SurroundNodes[j];
                        if (IsInCloseList(nextNode))
                        {
                            continue;
                        }
                        if (IsInOpenList(nextNode))
                        {
                            var oldNodeValue = nextNode.F;
                            var nextNodeValue = currentNode.F + nextNode.Cost + nextNode.H;
                            if (nextNodeValue < oldNodeValue) //use new
                            {
                                nextNode.G = currentNode.F;
                                nextNode.ParentNode = currentNode;
                                continue;
                            }
                        }
                        else
                        {
                            nextNode.ParentNode = currentNode;
                            nextNode.G = currentNode.F;
                            if (!tempNeedAddNodes.Contains(nextNode))
                            {
                                tempNeedAddNodes.Add(nextNode);
                            }
                        }
                    }
                }
                RemoveFromOpenList(currentNode);
                AddInCloseList(currentNode);
            }

            for (int i = 0; i < tempNeedAddNodes.Count; i++)
            {
                AddInOpenList(tempNeedAddNodes[i]);
            }

            if (_openList.Count > 0)
            {
                Recursion();
            }
        }

        /// <summary>
        /// If node in close list
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsInCloseList(Node node)
        {
            return _closeList.Contains(node);
        }

        /// <summary>
        /// If node in open list
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsInOpenList(Node node)
        {
            return _openList.Contains(node);
        }

        /// <summary>
        /// Add into open list
        /// </summary>
        /// <param name="node"></param>
        private void AddInOpenList(Node node)
        {
            if (!_openList.Contains(node))
            {
                _openList.Add(node);
            }
        }

        /// <summary>
        /// Remove from open list
        /// </summary>
        /// <param name="node"></param>
        private void RemoveFromOpenList(Node node)
        {
            if (_openList.Contains(node))
            {
                _openList.Remove(node);
            }
        }

        /// <summary>
        /// Add into close list
        /// </summary>
        /// <param name="node"></param>
        private void AddInCloseList(Node node)
        {
            if (!_closeList.Contains(node))
            {
                _closeList.Add(node);
            }
        }

        /// <summary>
        /// Sucess find path
        /// </summary>
        /// <param name="node"></param>
        private void Success(Node node)
        {
            _openList.Clear();
            _closeList.Clear();
            while (node != null)
            {
                _path.Insert(0, node);
                node = node.ParentNode;
            }
        }
    }
}