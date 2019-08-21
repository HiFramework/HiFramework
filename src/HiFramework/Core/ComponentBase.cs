/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// Component base class
    /// </summary>
    public abstract class ComponentBase
    {
        /// <summary>
        /// When instance created
        /// </summary>
        public abstract void OnCreated();

        /// <summary>
        /// When instance destroy
        /// </summary>
        public abstract void OnDestroy();
    }
}
