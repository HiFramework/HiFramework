///****************************************************************************
// * Description:Common log processer
// *
// * Author: hiramtan@live.com
// ****************************************************************************/

using System;

namespace HiFramework
{
    class ConsoleLogger : ILogHandler
    {
        public void Info(params object[] args)
        {
            Console.WriteLine(Log.GetFormat("Info") + args);
        }

        public void Warning(params object[] args)
        {
            Console.WriteLine(Log.GetFormat("Warning") + args);
        }

        public void Error(params object[] args)
        {
            Console.WriteLine(Log.GetFormat("Error") + args);
        }
    }
}
