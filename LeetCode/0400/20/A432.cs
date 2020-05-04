using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0400._20
{
    class A432 : IQuestion
    {
        public void Run()
        {
            var ins = new AllOne();
            ins.Inc("leet");
            ins.Inc("leet");
            var k = ins.GetMaxKey();
            k = ins.GetMinKey();
            ins.Inc("code");
            k = ins.GetMinKey();
        }

        public class AllOne
        {
            private LinkedList<NodeInfo> _list = new LinkedList<NodeInfo>();
            private readonly Dictionary<string, int> _map = new Dictionary<string, int>();
            private readonly Dictionary<int, LinkedListNode<NodeInfo>> _counter = new Dictionary<int, LinkedListNode<NodeInfo>>();

            /** Initialize your data structure here. */
            public AllOne()
            {
                _list.AddFirst(new NodeInfo { });
                _list.AddLast(new NodeInfo { });
            }

            /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
            public void Inc(string key)
            {
                LinkedListNode<NodeInfo> prev = null;
                if (_map.TryGetValue(key, out var count))
                {
                    prev = _counter[count];
                    prev.Value.Keys.Remove(key);
                }
                count++;
                _map[key] = count;
                if (!_counter.TryGetValue(count, out var node))
                {
                    if (prev == null)
                    {
                        node = _list.AddAfter(_list.First, new NodeInfo { Count = count });
                    }
                    else
                    {
                        node = _list.AddAfter(prev, new NodeInfo { Count = count });
                    }
                    _counter.Add(count, node);
                }
                node.Value.Keys.Add(key);
                if (prev != null && prev.Value.Keys.Count == 0)
                {
                    _list.Remove(prev);
                    _counter.Remove(prev.Value.Count);
                }
            }

            /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
            public void Dec(string key)
            {
                if (!_map.TryGetValue(key, out var count))
                {
                    return;
                }
                var prev = _counter[count];
                prev.Value.Keys.Remove(key);
                count--;
                if (count == 0)
                {
                    _map.Remove(key);
                }
                else
                {
                    _map[key] = count;
                    if (!_counter.TryGetValue(count, out var node))
                    {
                        node = _list.AddBefore(prev, new NodeInfo { Count = count });
                        _counter.Add(count, node);
                    }
                    node.Value.Keys.Add(key);
                }
                if (prev.Value.Keys.Count == 0)
                {
                    _list.Remove(prev);
                    _counter.Remove(prev.Value.Count);
                }
            }

            /** Returns one of the keys with maximal value. */
            public string GetMaxKey()
            {
                if (_list.Count == 2)
                {
                    return string.Empty;
                }
                return _list.Last.Previous.Value.Keys.First();
            }

            /** Returns one of the keys with Minimal value. */
            public string GetMinKey()
            {
                if (_list.Count == 2)
                {
                    return string.Empty;
                }
                return _list.First.Next.Value.Keys.First();
            }

            public class NodeInfo
            {
                public HashSet<string> Keys { get; } = new HashSet<string>();
                public int Count { get; set; }
            }
        }
    }
}
