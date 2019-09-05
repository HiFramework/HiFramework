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

        public FastDictionary(int size = 1 << 7)
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
                TryGet(key, out TValue value);
                return value;
            }
            set { TrySet(key, value); }
        }

        public bool ContainsKey(TKey key)
        {
            return TryGet(key, out TValue value);
        }


        public bool TryGet(TKey key, out TValue value)
        {
            for (int i = 0; i < _index; i++)
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

        public bool TrySet(TKey key, TValue value)
        {
            var isTrue = TryGet(key, out TValue tValue);
            if (isTrue)
            {
                return false;
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
                _entries = null;
                _entries = newEntries;
                _entries[_index] = entry;
                _index++;
            }
            return true;
        }

        public bool TryRemove(TKey key)
        {
            bool isTrue = false;
            int index = 0;
            for (int i = 0; i < _index; i++)
            {
                if (_comparer.Equals(key, _entries[i].Key))
                {
                    index = i;
                    isTrue = true;
                }
            }
            if (isTrue)
            {
                for (int i = index; i < _index; i++)
                {
                    _entries[i] = _entries[i + 1];
                }
                _index--;
            }
            return isTrue;
        }

        public TKey[] GetAllKeys()
        {
            var keys = new TKey[_index];
            for (int i = 0; i < _index; i++)
            {
                keys[i] = _entries[i].Key;
            }
            return keys;
        }

        public TValue[] GetAllValues()
        {
            var values = new TValue[_index];
            for (int i = 0; i < _index; i++)
            {
                values[i] = _entries[i].Value;
            }
            return values;
        }

        public void Clear()
        {
            _index = 0;
        }
    }
}