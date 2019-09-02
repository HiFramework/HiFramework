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
    public class Node
    {
        /// <summary>
        /// Current node cost
        /// </summary>
        public float Cost = 1;//default cost

        /// <summary>
        /// Surround connected node
        /// </summary>
        public List<Node> SurroundNodes = new List<Node>();

        /// <summary>
        /// Parent node
        /// </summary>
        internal Node ParentNode;

        /// <summary>
        /// Total cost
        /// </summary>
        internal float F;

        /// <summary>
        /// Cost from start node
        /// </summary>
        internal float G;

        /// <summary>
        /// Will Cost to end
        /// </summary>
        internal float H;
    }
}