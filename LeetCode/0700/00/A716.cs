using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0700._00
{
    class A716 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MaxStack
        {
            private readonly LinkedList<int> _list = new LinkedList<int>();
            private readonly LinkedListNode<int> _first;
            private readonly LinkedListNode<int> _last;
            private readonly SortedDictionary<int, List<LinkedListNode<int>>> _sorted = new SortedDictionary<int, List<LinkedListNode<int>>>(new DescComparer());

            /** initialize your data structure here. */
            public MaxStack()
            {
                _first = _list.AddFirst(0);
                _last = _list.AddLast(0);
            }

            public void Push(int x)
            {
                var node = _list.AddBefore(_last, x);
                if (!_sorted.TryGetValue(x, out var list))
                {
                    list = new List<LinkedListNode<int>>();
                    _sorted.Add(x, list);
                }
                list.Add(node);
            }

            public int Pop()
            {
                var node = _last.Previous;
                _sorted.TryGetValue(node.Value, out var list);
                list.RemoveAt(list.Count - 1);
                if (list.Count == 0)
                {
                    _sorted.Remove(node.Value);
                }
                _list.Remove(node);
                return node.Value;
            }

            public int Top()
            {
                return _last.Previous.Value;
            }

            public int PeekMax()
            {
                return _sorted.First().Key;
            }

            public int PopMax()
            {
                var list = _sorted.First().Value;
                var node = list.Last();
                list.RemoveAt(list.Count - 1);
                if (list.Count == 0)
                {
                    _sorted.Remove(node.Value);
                }
                _list.Remove(node);
                return node.Value;
            }

            private class DescComparer : IComparer<int>
            {
                public int Compare(int x, int y)
                {
                    return y.CompareTo(x);
                }
            }
        }
    }
}
