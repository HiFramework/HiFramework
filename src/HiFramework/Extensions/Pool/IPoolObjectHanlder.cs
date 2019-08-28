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
    public interface IPoolObjectHanlder<T>
    {
        /// <summary>
        /// When object created
        /// </summary>
        T OnObjectCreated();

        /// <summary>
        /// When object destroy
        /// </summary>
        void OnObjectDestroy(T o);

        /// <summary>
        /// When object in pool
        /// </summary>
        void OnObjectInPool(T o);

        /// <summary>
        /// When object out pool
        /// </summary>
        void OnObjectOutPool(T t);
    }
}
