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
    /// Will do task every day at xx:xx(14:20)
    /// </summary>
    public class ScheduleTask : IDisposable
    {
        private string _time;
        private System.Action _task;

        private System.Timers.Timer _firstTimer;
        private System.Timers.Timer _tickTimer;

        /// <summary>
        /// A new _task
        /// </summary>
        /// <param name="time">"14:20"</param>
        /// <param name="task"></param>
        public ScheduleTask(string time, System.Action task)
        {
            _time = time;
            _task = task;
        }

        public void Start()
        {
            DateTime to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                int.Parse(_time.Split(':')[0]), int.Parse(_time.Split(':')[1]), 0);
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
            _firstTimer = new System.Timers.Timer(offsetTime);
            _firstTimer.Elapsed += FirstElapsed;
            _firstTimer.AutoReset = false;
            _firstTimer.Enabled = true;
        }

        void FirstElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);
            var offsetTime = ts.TotalMilliseconds;
            _tickTimer = new System.Timers.Timer(offsetTime);
            _tickTimer.Elapsed += TickElapsed;
            _tickTimer.AutoReset = true;
            _tickTimer.Enabled = true;
            Execute();
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

        public void Stop()
        {
            _firstTimer.Enabled = false;
            _tickTimer.Enabled = false;
        }

        public void Dispose()
        {
            Stop();
            _task = null;
            _firstTimer = null;
            _tickTimer = null;
        }
    }
}
