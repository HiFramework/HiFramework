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
    public interface IPool<T> : IDisposable
    {
        /// <summary>
        /// Get count of object's numb
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Get object
        /// </summary>
        /// <returns></returns>
        T GetObject();

        /// <summary>
        /// Get object async
        /// </summary>
        /// <returns></returns>
        void GetObjectAsync(Action<T> onFinish);

        /// <summary>
        /// Recleim object
        /// </summary>
        /// <param name="t"></param>
        void RecleimObject(T t);
    }
}
