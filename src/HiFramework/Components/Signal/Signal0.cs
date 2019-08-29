/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public class Signal
    {

        private System.Action _action;

        public void AddListener(System.Action action)
        {
            _action += action;
        }

        public void RemoveListener(System.Action action)
        {
            _action -= action;
        }

        public void Fire()
        {
            AssertThat.IsNotNull(_action, "Action is null, add listener first");
            _action();
        }
    }
}
