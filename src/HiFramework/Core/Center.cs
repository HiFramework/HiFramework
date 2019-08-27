/****************************************************************************
 * Description: This is the public interface for user call framework api
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

 namespace HiFramework
{
    /// <summary>
    /// Most common use for call framework api
    /// </summary>
    public static class Center
    {
        /// <summary>
        /// Contain bind infos and instance infos
        /// </summary>
        private static Container _container;

        /// <summary>
        /// Initialize binder
        /// </summary>
        /// <param name="binder"></param>
        public static void Init(Binder binder)
        {
            AssertThat.IsNotNull(binder, "Binder is null");
            binder.Init();
            _container = new Container(binder);
        }

        /// <summary>
        /// If component is instantiated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsComponentExist<T>()
        {
            return _container.IsComponentExist<T>();
        }

        /// <summary>
        /// Get instance by interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
        {
            return _container.Get<T>();
        }

        /// <summary>
        /// Remove instance by interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Remove<T>()
        {
            _container.Remove<T>();
        }

        /// <summary>
        /// Dispose all componets
        /// </summary>
        public static void Dispose()
        {
            _container.Dispose();
        }
    }
}