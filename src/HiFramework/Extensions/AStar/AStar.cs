/****************************************************************************
 * Description: Common node logic
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
    public static class AStar
    {
        /// <summary>
        /// Total node numb to find
        /// </summary>
        public static int MaxNodeCount = 1024;
        /// <summary>
        /// This is a sync api
        /// Find node path by start and end node
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Node> Find(Node start, Node end)
        {
            return new Searcher(MaxNodeCount).Find(start, end);
        }

        /// <summary>
        /// This is a async api
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="callback"></param>
        public static void Find(Node start, Node end, AsyncCallback callback)
        {

        }
    }
}
