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
    internal class SignalComponent : ComponentBase, ISignal
    {
        private readonly Dictionary<string, object> _signals = new Dictionary<string, object>();
        public override void OnCreated()
        {
        }

        public override void OnDestroy()
        {
        }

        public T GetSignal<T>() where T : class
        {
            var t = typeof(T);
            if (_signals.ContainsKey(t.FullName))
            {
                return _signals[t.FullName] as T;
            }
            return CreateSignal(t) as T;
        }

        public void RemoveSignal<T>() where T : class
        {
            var t = typeof(T);
            AssertThat.IsTrue(_signals.ContainsKey(t.FullName), "Do not have this signal");
            _signals.Remove(t.FullName);
        }

        private object CreateSignal(Type t)
        {
            var signal = Activator.CreateInstance(t);
            AssertThat.IsNotNull(signal, "Create signal faild");
            _signals[t.FullName] = signal;
            return signal;
        }
    }
}
