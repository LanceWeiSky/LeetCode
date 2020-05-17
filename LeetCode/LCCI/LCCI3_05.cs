using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI3_05 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class SortedStack
        {
            private readonly Stack<int> _stack1 = new Stack<int>();
            private readonly Stack<int> _stack2 = new Stack<int>();


            public SortedStack()
            {

            }

            public void Push(int val)
            {
                while (_stack1.Count > 0 && _stack1.Peek() < val)
                {
                    _stack2.Push(_stack1.Pop());
                }
                while (_stack2.Count > 0 && _stack2.Peek() > val)
                {
                    _stack1.Push(_stack2.Pop());
                }
                _stack1.Push(val);
            }

            private void PrepareToPop()
            {
                while (_stack2.Count > 0)
                {
                    _stack1.Push(_stack2.Pop());
                }
            }

            public void Pop()
            {
                PrepareToPop();
                if (_stack1.Count == 0)
                {
                    return;
                }
                _stack1.Pop();
            }

            public int Peek()
            {
                PrepareToPop();
                if (_stack1.Count == 0)
                {
                    return -1;
                }
                return _stack1.Peek();
            }

            public bool IsEmpty()
            {
                return _stack1.Count == 0 && _stack2.Count == 0;
            }
        }
    }
}
