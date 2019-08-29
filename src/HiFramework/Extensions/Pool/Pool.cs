/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class Pool<T> : IPool<T>
    {
        private readonly List<T> _objects = new List<T>();
        private IPoolObjectHanlder<T> _hanlder;

        public int Count
        {
            get { return _objects.Count; }
        }

        public Pool(IPoolObjectHanlder<T> handler)
        {
            _hanlder = handler;
        }

        public T GetObject()
        {
            T t;
            if (_objects.Count > 0)
            {
                t = _objects[0];
                _objects.RemoveAt(0);
                _hanlder.OnObjectOutPool(t);
            }
            else
            {
                t = _hanlder.OnObjectCreated();
            }
            return t;
        }

        /// <summary>
        /// Get object async
        /// </summary>
        /// <returns></returns>
        public void GetObjectAsync(Action<T> onFinish)
        {
            T t;
            if (_objects.Count > 0)
            {
                t = _objects[0];
                _objects.RemoveAt(0);
                _hanlder.OnObjectOutPool(t);
                onFinish(t);
            }
            else
            {
                _hanlder.OnObjectCreatedAsync(onFinish);
            }
        }


        public void RecleimObject(T t)
        {
            AssertThat.IsFalse(_objects.Contains(t), "Already have this object");
            _objects.Add(t);
            _hanlder.OnObjectInPool(t);
        }

        public void Dispose()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _hanlder.OnObjectDestroy(_objects[i]);
            }
            _objects.Clear();
        }
    }
}