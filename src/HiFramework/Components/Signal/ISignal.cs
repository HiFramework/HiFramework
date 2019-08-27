/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    public interface ISignal
    {
        /// <summary>
        /// Get signal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetSignal<T>() where T : class;

        /// <summary>
        /// Remove Signal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RemoveSignal<T>() where T : class;
    }
}