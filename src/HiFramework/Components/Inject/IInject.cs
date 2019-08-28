/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public interface IInject
    {
        /// <summary>
        /// Bind a type to a instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        InjectBinding Bind<T>();

        /// <summary>
        /// Inject by type
        /// Only property and filed for current now
        /// </summary>
        /// <param name="args"></param>
        void Inject(Type args, string name = null);

        /// <summary>
        /// Inject by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Inject<T>(string name = null);
    }
}
