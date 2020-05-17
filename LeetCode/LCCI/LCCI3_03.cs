using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI3_03 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class StackOfPlates
        {

            private readonly List<Stack<int>> _list = new List<Stack<int>>();
            private readonly int _cap;

            public StackOfPlates(int cap)
            {
                _cap = cap;
            }

            public void Push(int val)
            {
                if (_cap == 0)
                {
                    return;
                }
                if (_list.Count == 0 || _list.Last().Count == _cap)
                {
                    _list.Add(new Stack<int>(_cap));
                }
                _list.Last().Push(val);
            }

            public int Pop()
            {
                if (_list.Count > 0)
                {
                    var value = _list.Last().Pop();
                    if (_list.Last().Count == 0)
                    {
                        _list.RemoveAt(_list.Count - 1);
                    }
                    return value;
                }
                return -1;
            }

            public int PopAt(int index)
            {
                if (index < _list.Count)
                {
                    var value = _list[index].Pop();
                    if (_list[index].Count == 0)
                    {
                        _list.RemoveAt(index);
                    }
                    return value;
                }
                return -1;
            }
        }
    }
}
