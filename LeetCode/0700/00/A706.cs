using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._00
{
    class A706 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyHashMap
        {
            private const int SIZE = 2069;
            private readonly Bucket[] _values = new Bucket[2069];

            /** Initialize your data structure here. */
            public MyHashMap()
            {
                
            }

            private int GetIndex(int key)
            {
                return key.GetHashCode() % SIZE;
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                var index = GetIndex(key);
                if (_values[index] == null)
                {
                    _values[index] = new Bucket();
                }
                _values[index].UpdateValue(key, value);
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                var index = GetIndex(key);
                if (_values[index] == null)
                {
                    return -1;
                }
                return _values[index].GetValue(key);
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                var index = GetIndex(key);
                if (_values[index] != null)
                {
                    _values[index].Remove(key);
                }
            }
        }

        public class Bucket
        {
            private LinkedList<BucketItem> _list = new LinkedList<BucketItem>();

            public Bucket()
            {
                _list.AddFirst(new BucketItem(0, 0));
            }

            private BucketItem Find(int key)
            {
                var p = _list.First;
                while (p.Next != null)
                {
                    p = p.Next;
                    if (p.Value.Key == key)
                    {
                        return p.Value;
                    }
                }
                return null;
            }

            public int GetValue(int key)
            {
                var item = Find(key);
                if (item != null)
                {
                    return item.Value;
                }
                return -1;
            }

            public void UpdateValue(int key, int value)
            {
                var item = Find(key);
                if (item == null)
                {
                    _list.AddAfter(_list.First, new BucketItem(key, value));
                }
                else
                {
                    item.Value = value;
                }
            }

            public void Remove(int key)
            {
                var item = Find(key);
                if (item != null)
                {
                    _list.Remove(item);
                }
            }
        }

        public class BucketItem
        { 
            public int Key { get; }

            public int Value { get; set; }

            public BucketItem(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
