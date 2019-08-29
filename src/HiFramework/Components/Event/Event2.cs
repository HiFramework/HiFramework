/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    internal class Event<T, U> : EventBase
    {
        private Action<T, U> _action;
        public Event(Action<T, U> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 2)
            {
                _action((T)objects[0], (U)objects[1]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}
