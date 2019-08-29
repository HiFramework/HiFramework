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
    /// Start a task in thread and finish it on main thread
    /// </summary>
    public interface IThreadTask
    {
        /// <summary>
        /// Start task
        /// </summary>
        void Start();

        /// <summary>
        /// Stop task
        /// </summary>
        void Stop();
    }
}