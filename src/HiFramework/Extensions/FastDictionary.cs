/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HiFramework
{
    /// <summary>
    /// This is a key value type
    /// Only have the construction of key-value
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class FastDictionary<TKey, TValue>
    {
        struct Entry
        {
            public TKey Key;
            public TValue Value;
        }

        private int _size;
        private int _index;
        private Entry[] _entries;

        private IEqualityComparer<TKey> _comparer;

        public FastDictionary(int size = 1 << 10)
        {
            _size = size;
            _index = 0;
            _entries = new Entry[size];
            _comparer = EqualityComparer<TKey>.Default;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                TryGet(key, out value);
                return value;
            }
            set { Set(key, value); }
        }


        private bool TryGet(TKey key, out TValue value)
        {
            for (int i = 0; i < _entries.Length; i++)
            {
                if (_comparer.Equals(key, _entries[i].Key))
                {
                    value = _entries[i].Value;
                    return true;
                }
            }
            value = default(TValue);
            return false;
        }

        private void Set(TKey key, TValue value)
        {
            TValue tValue;
            var isTrue = TryGet(key, out tValue);
            if (isTrue)
            {
                throw new ArgumentException("Already have this key");
            }

            var entry = new Entry();
            entry.Key = key;
            entry.Value = value;

            if (_index < _entries.Length)
            {
                _entries[_index] = entry;
                _index++;
            }
            else
            {
                var capacity = _entries.Length + _size;
                var newEntries = new Entry[capacity];
                Buffer.BlockCopy(_entries, 0, newEntries, 0, _entries.Length);
                _entries = null;//alloc
                _entries = newEntries;
                _entries[_index] = entry;
                _index++;
            }
        }
    }
}
