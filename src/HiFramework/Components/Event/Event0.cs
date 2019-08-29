/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 无参数回调
    /// </summary>
    internal class Event : EventBase
    {
        private System.Action _action;
        public Event(System.Action action)
        {
            _action = action;
        }

        public override void Dispatch(params object[] objects)
        {
            if (objects == null || objects.Length == 0)
            {
                _action();
            }
            else
            {
                ParamMatchError();
            }
        }
    }
}