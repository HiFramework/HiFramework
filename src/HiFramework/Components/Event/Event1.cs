/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 一个参数类型的回调
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Event<T> : EventBase
    {
        private Action<T> _action;
        public Event(Action<T> action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects != null && objects.Length == 1 && objects[0] is T)
            {
                _action((T)objects[0]);
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}