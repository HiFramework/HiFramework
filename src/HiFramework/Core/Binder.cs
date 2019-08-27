/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// Manage bind infos
    /// </summary>
    public abstract class Binder
    {
        /// <summary>
        /// Contain bind infos
        /// </summary>
        internal readonly Dictionary<Type, Type> BindInfos = new Dictionary<Type, Type>();

        /// <summary>
        /// For sub class fullfill bind logic
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Bind interface to?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected BindInfo<T> Bind<T>() where T : class
        {
            return new BindInfo<T>(this);
        }

        /// <summary>
        /// Set bind infos
        /// </summary>
        /// <param name="key"></param>
        /// <param name="component"></param>
        internal void SetKeyAndComponent(Type key, Type component)
        {
            AssertThat.IsFalse(BindInfos.ContainsKey(key), "Already have this key" + key.ToString());
            BindInfos[key] = component;
        }
    }
}