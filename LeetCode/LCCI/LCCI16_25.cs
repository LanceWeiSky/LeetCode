using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI16_25 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class LRUCache
        {
            public class LRUNode
            {
                public int Key { get; set; }
                public int Value { get; set; }
                public LRUNode Prev { get; set; }
                public LRUNode Next { get; set; }

            }

            private LRUNode _head = new LRUNode();
            private LRUNode _tail = new LRUNode();
            private Dictionary<int, LRUNode> _cache;
            private int _capacity;

            public LRUCache(int capacity)
            {
                _capacity = capacity;
                _cache = new Dictionary<int, LRUNode>(capacity);
                _head.Next = _tail;
                _tail.Prev = _head;
            }

            private void RemoveNode(LRUNode node)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }

            private void AddToHead(LRUNode node)
            {
                _head.Next.Prev = node;
                node.Next = _head.Next;
                node.Prev = _head;
                _head.Next = node;
            }

            private LRUNode PopTail()
            {
                var node = _tail.Prev;
                RemoveNode(node);
                return node;
            }

            public int Get(int key)
            {
                if (_cache.TryGetValue(key, out var value))
                {
                    RemoveNode(value);
                    AddToHead(value);
                    return value.Value;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (_capacity == 0)
                {
                    return;
                }
                if (_cache.TryGetValue(key, out var node))
                {
                    RemoveNode(node);
                    AddToHead(node);
                    node.Value = value;
                }
                else
                {
                    if (_capacity == _cache.Count)
                    {
                        node = PopTail();
                        _cache.Remove(node.Key);
                    }
                    node = new LRUNode { Key = key, Value = value };
                    _cache[key] = node;
                    AddToHead(node);
                }
            }
        }
    }
}
