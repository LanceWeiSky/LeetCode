using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A146 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //运用你所掌握的数据结构，设计和实现一个 LRU(最近最少使用) 缓存机制。它应该支持以下操作： 获取数据 get 和 写入数据 put 。

        //获取数据 get(key) - 如果密钥(key) 存在于缓存中，则获取密钥的值（总是正数），否则返回 -1。
        //写入数据 put(key, value) - 如果密钥已经存在，则变更其数据值；如果密钥不存在，则插入该组「密钥/数据值」。当缓存容量达到上限时，它应该在写入新数据之前删除最久未使用的数据值，从而为新的数据值留出空间。



        //进阶:

        //你是否可以在 O(1) 时间复杂度内完成这两种操作？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/lru-cache
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

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
