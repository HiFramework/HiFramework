/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    /// <summary>
    /// Per bind info
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindInfo<T>
    {
        /// <summary>
        /// Binder 
        /// </summary>
        private readonly Binder _binder;

        internal BindInfo(Binder binder)
        {
            _binder = binder;
        }

        /// <summary>
        /// Bind to component
        /// </summary>
        /// <typeparam name="U"></typeparam>
        public void To<U>() where U : ComponentBase, new()
        {
            var key = typeof(T);
            var component = typeof(U);
            _binder.SetKeyAndComponent(key, component);
        }
    }
}
