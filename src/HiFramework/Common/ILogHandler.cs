///****************************************************************************
// * Description:Common log processer
// *
// * Author: hiramtan@live.com
// ****************************************************************************/

namespace HiFramework
{
    public interface ILogHandler
    {
        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="args"></param>
        void Info(params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="args"></param>
        void Warning(params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="args"></param>
        void Error(params object[] args);
    }
}