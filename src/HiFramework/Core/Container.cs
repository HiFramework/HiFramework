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
        private readonly Dictionary<Type, ComponentBase> _components = new Dictionary<Type, ComponentBase>();

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
            var key = typeof(T);
            ComponentBase componentBase = null;
            _components.TryGetValue(key, out componentBase);
            if (componentBase != null)
            {
                return componentBase as T;
            }
            return CreateComponent<T>(key) as T;
        }

        /// <summary>
        /// If component Exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal bool IsComponentExist<T>()
        {
            var key = typeof(T);
            return _components.ContainsKey(key);
        }

        /// <summary>
        /// Remove component by interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal void Remove<T>()
        {
            var key = typeof(T);
            ComponentBase c = null;
            _components.TryGetValue(key, out c);
            if (c != null)
            {
                _components.Remove(key);
                c.OnDestroy();
            }
            else
            {
                AssertThat.Fail("ComponentBase is not exist" + key.FullName.ToString());
            }
        }

        /// <summary>
        /// Dispose framework
        /// </summary>
        internal void Dispose()
        {
            foreach (var component in _components)
            {
                AssertThat.IsNotNull(component.Value, "Component is null" + component.Key.FullName);
                component.Value.OnDestroy();
            }
        }

        /// <summary>
        /// Create componentBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private ComponentBase CreateComponent<T>(Type key)
        {
            var componentType = _binder.BindInfos[key];
            AssertThat.IsNotNull(componentType, "Have not bind this type");
            var c = Activator.CreateInstance(componentType) as ComponentBase;
            AssertThat.IsNotNull(c, "Create component faild");
            AssertThat.IsFalse(_components.ContainsKey(key), "Already have this component");
            _components[key] = c;
            c.OnCreated();
            return c;
        }
    }
}
