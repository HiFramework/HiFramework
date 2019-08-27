/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    /// <summary>
    /// Will do task every day at xx:xx(14:20)
    /// </summary>
    public class ScheduleTask
    {
        private Action _task;

        /// <summary>
        /// A new _task
        /// </summary>
        /// <param name="time">"14:20"</param>
        /// <param name="task"></param>
        public ScheduleTask(string time, Action task)
        {
            _task = task;

            DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                int.Parse(time.Split(':')[0]), int.Parse(time.Split(':')[1]), 0);
            var offset = to - DateTime.Now;
            var offsetTime = offset.TotalMilliseconds;
            if (offsetTime > 0) //today
            {
            }
            else//tomorrow
            {
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);
                offsetTime = (offset + ts).TotalMilliseconds;
            }
            System.Timers.Timer t = new System.Timers.Timer(offsetTime);
            t.Elapsed += FirstElapsed;
            t.AutoReset = false;
            t.Enabled = true;
        }

        void FirstElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            Execute();
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);
            var offsetTime = ts.TotalMilliseconds;
            System.Timers.Timer t = new System.Timers.Timer(offsetTime);
            t.Elapsed += TickElapsed;
            t.AutoReset = true;
            t.Enabled = true;
        }

        void TickElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            Execute();
        }

        void Execute()
        {
            if (_task != null)
            {
                _task.Invoke();
            }
        }
    }
}
