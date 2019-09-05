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
    /// Instance infos
    /// </summary>
    internal class Container
    {
        /// <summary>
        /// Binder infos
        /// </summary>
        private readonly Binder _binder;

        /// <summary>
        /// Instance infos
        /// </summary>
        private readonly FastDictionary<string, ComponentBase> _components = new FastDictionary<string, ComponentBase>();

        public Container(Binder binder)
        {
            _binder = binder;
        }

        /// <summary>
        /// Get component by interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T Get<T>() where T : class
        {
            var t = typeof(T);
            bool isTrue = _components.TryGet(t.FullName, out ComponentBase componentBase);
            if (isTrue)
            {
                return componentBase as T;
            }
            return CreateComponent<T>(t) as T;
        }

        /// <summary>
        /// If component Exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal bool IsComponentExist<T>()
        {
            var t = typeof(T);
            return _components.ContainsKey(t.FullName);
        }

        /// <summary>
        /// Remove component by interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal void Remove<T>()
        {
            var t = typeof(T);
            bool isTrue = _components.TryGet(t.FullName, out ComponentBase c);
            if (isTrue)
            {
                _components.TryRemove(t.FullName);
                c.OnDestroy();
            }
            else
            {
                AssertThat.Fail("ComponentBase is not exist" + t.FullName.ToString());
            }
        }

        /// <summary>
        /// Dispose framework
        /// </summary>
        internal void Dispose()
        {
            var components = _components.GetAllValues();
            foreach (var component in components)
            {
                AssertThat.IsNotNull(component, "Component is null");
                component.OnDestroy();
            }
            _components.Clear();
        }

        /// <summary>
        /// Create componentBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private ComponentBase CreateComponent<T>(Type t)
        {
            var componentType = _binder.BindInfos[t];
            AssertThat.IsNotNull(componentType, "Have not bind this type");
            var c = Activator.CreateInstance(componentType) as ComponentBase;
            AssertThat.IsNotNull(c, "Create component faild");
            AssertThat.IsFalse(_components.ContainsKey(t.FullName), "Already have this component");
            _components[t.FullName] = c;
            c.OnCreated();
            return c;
        }
    }
}
