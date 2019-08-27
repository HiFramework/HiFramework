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
    internal class EventComponent : ComponentBase, IEvent
    {
        /// <summary>
        /// Hold the events user registed
        /// </summary>
        private readonly Dictionary<string, List<ActionBase>> _container = new Dictionary<string, List<ActionBase>>();

        /// <summary>
        /// Subscribe event with no param
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Subscribe(string key, Action action)
        {
            var handler = new Action_0(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Subscribe one param event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Subscribe<T>(string key, Action<T> action)
        {
            var handler = new Action_1<T>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Subscribe two param event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Subscribe<T, U>(string key, Action<T, U> action)
        {
            var handler = new Action_2<T, U>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Registe three parameter event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Subscribe<T, U, V>(string key, Action<T, U, V> action)
        {
            var handler = new Action_3<T, U, V>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Registe four parameter event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Subscribe<T, U, V, W>(string key, Action<T, U, V, W> action)
        {
            var handler = new Action_4<T, U, V, W>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// This method handle one key with multiple action
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        private void RegistHandler(string key, ActionBase handler)
        {
            if (_container.ContainsKey(key))
            {
                _container[key].Add(handler);
            }
            else
            {
                var list = new List<ActionBase>();
                list.Add(handler);
                _container.Add(key, list);
            }
        }

        /// <summary>
        /// Fire the event
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Dispatch(string key, params object[] obj)
        {
            List<ActionBase> v = null;
            var isTrue = _container.TryGetValue(key, out v);
            AssertThat.IsTrue(isTrue, "Do not have this key");
            foreach (var info in v)
            {
                info.Dispatch(obj);
            }
        }

        /// <summary>
        /// Remove key and all its actions
        /// </summary>
        /// <param name="key"></param>
        public void RemoveListener(string key)
        {
            AssertThat.IsTrue(_container.ContainsKey(key), "Do not have this key");
            _container[key].Clear();
            _container.Remove(key);
        }

        public override void OnCreated()
        {

        }

        /// <summary>
        /// This will fired on component destoryed
        /// </summary>
        public override void OnDestroy()
        {
            foreach (var variable in _container)
            {
                variable.Value.Clear();
            }
            _container.Clear();
        }
    }
}
