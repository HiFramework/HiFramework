//*********************************************************************
// Description:安全单例
// 提供两种类型的书写方式,如果类不能继承singleton<T>时,可以使用第二种方式快速提供单例
// Author: hiramtan@live.com
//*********************************************************************

namespace HiFramework
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        private static readonly object Locker = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public static class Singleton
    {
        private static object _locker = new object();

        public static T GetInstance<T>() where T : class, new()
        {
            if (InstanceStorage<T>.Instance == null)
            {
                lock (_locker)
                {
                    if (InstanceStorage<T>.Instance == null)
                    {
                        InstanceStorage<T>.Instance = new T();
                    }
                }
            }
            return InstanceStorage<T>.Instance;
        }

        private static class InstanceStorage<T> where T : class, new()
        {
            internal static volatile T Instance = default(T);
        }
    }
}

////example
//public class Test_First : Singleton<Test_First>
//{
//    public void Do() { }
//}

//public class Test_Second
//{
//    public void Do() { }
//}

//public class Test1
//{
//    void Init()
//    {
//        Test_First.Instance.Do();
//        Singleton.GetInstance<Test_Second>().Do();
//    }
//}