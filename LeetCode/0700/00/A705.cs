using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._00
{
    class A705 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyHashSet
        {
            private const int SIZE = 2069;
            private readonly Bucket[] _buckets = new Bucket[SIZE];

            /** Initialize your data structure here. */
            public MyHashSet()
            {

            }

            public void Add(int key)
            {
                int index = key % SIZE;
                if(_buckets[index] == null)
                {
                    _buckets[index] = new Bucket();
                }
                _buckets[index].Add(key);
            }

            public void Remove(int key)
            {
                int index = key % SIZE;
                if (_buckets[index] != null)
                {
                    _buckets[index].Remove(key);
                }
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                int index = key % SIZE;
                if (_buckets[index] != null)
                {
                    return _buckets[index].Contains(key);
                }
                return false;
            }

            internal class Bucket
            {
                private readonly LinkedList<int> _list = new LinkedList<int>();

                internal Bucket()
                {
                    _list.AddFirst(-1);
                }

                private LinkedListNode<int> Find(int value)
                {
                    var node = _list.First;
                    while (node.Next != null)
                    {
                        node = node.Next;
                        if (node.Value == value)
                        {
                            return node;
                        }
                    }
                    return null;
                }

                public void Add(int value)
                {
                    var node = Find(value);
                    if (node == null)
                    {
                        _list.AddAfter(_list.First, value);
                    }
                }

                public void Remove(int value)
                {
                    var node = Find(value);
                    if (node != null)
                    {
                        _list.Remove(node);
                    }
                }

                public bool Contains(int value)
                {
                    var node = Find(value);
                    return node != null;
                }
            }
        }

    }
}
