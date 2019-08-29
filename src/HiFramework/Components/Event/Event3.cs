/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    internal class Event<T, U, V> : EventBase
    {
        private Action<T, U, V> _action;
        public Event(Action<T, U, V> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 3)
            {
                _action((T)objects[0], (U)objects[1], (V)objects[2]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}
