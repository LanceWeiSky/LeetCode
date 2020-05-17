using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCode._1100._60
{
    class A1172 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class DinnerPlates
        {
            private readonly int _capacity;
            private readonly List<Stack<int>> _stacks = new List<Stack<int>>();
            private readonly SortedSet<StackInfo> _pop;
            private readonly SortedSet<StackInfo> _push;

            public DinnerPlates(int capacity)
            {
                _capacity = capacity;
                _pop = new SortedSet<StackInfo>(new StackComparer(0));
                _push = new SortedSet<StackInfo>(new StackComparer(_capacity));
            }

            public void Push(int val)
            {
                if (_capacity == 0)
                {
                    return;
                }
                if (_push.Count > 0)
                {
                    var min = _push.Min;
                    if (min.Count < _capacity)
                    {
                        _push.Remove(min);
                        _pop.Remove(min);
                        _stacks[min.Index].Push(val);
                        min.Count++;
                        _push.Add(min);
                        _pop.Add(min);
                        return;
                    }
                }
                Stack<int> stack = new Stack<int>(_capacity);
                stack.Push(val);
                var info = new StackInfo { Count = 1, Index = _stacks.Count };
                _stacks.Add(stack);
                _pop.Add(info);
                _push.Add(info);
            }

            public int Pop()
            {
                if (_capacity == 0 || _pop.Count == 0)
                {
                    return -1;
                }
                var min = _pop.Min;
                if (min.Count == 0)
                {
                    return -1;
                }
                var stack = _stacks[min.Index];
                var value = stack.Pop();
                _pop.Remove(min);
                _push.Remove(min);
                min.Count--;
                _pop.Add(min);
                _push.Add(min);
                return value;
            }

            public int PopAtStack(int index)
            {
                if (index < _stacks.Count)
                {
                    var stack = _stacks[index];
                    if (stack.Count > 0)
                    {
                        var info = new StackInfo { Count = stack.Count, Index = index };
                        _pop.Remove(info);
                        _push.Remove(info);
                        info.Count--;
                        _pop.Add(info);
                        _push.Add(info);
                        return stack.Pop();
                    }
                }
                return -1;
            }

            private class StackInfo
            {
                public int Count { get; set; }
                public int Index { get; set; }
            }

            private class StackComparer : IComparer<StackInfo>
            {
                private readonly int _capacity;
                internal StackComparer(int capacity)
                {
                    _capacity = capacity;
                }

                public int Compare(StackInfo x, StackInfo y)
                {
                    if (x.Count == _capacity && y.Count != _capacity)
                    {
                        return 1;
                    }
                    if (y.Count == _capacity && x.Count != _capacity)
                    {
                        return -1;
                    }
                    if (_capacity == 0)
                    {
                        return y.Index.CompareTo(x.Index);
                    }
                    return x.Index.CompareTo(y.Index);
                }
            }
        }
    }
}
