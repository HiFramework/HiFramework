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
            var str = Log.GetFormat("Info") + args;
            Console.WriteLine(str);
        }

        public void Warning(params object[] args)
        {
            var str = Log.GetFormat("Warning") + args;
            Console.WriteLine(str);
        }

        public void Error(params object[] args)
        {
            var str = Log.GetFormat("Error") + args;
            Console.WriteLine(str);
        }
    }
}
