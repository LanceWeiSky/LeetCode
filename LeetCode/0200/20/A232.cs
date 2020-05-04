using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A232 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyQueue
        {
            private Stack<int> _stack1 = new Stack<int>();
            private Stack<int> _stack2 = new Stack<int>();

            /** Initialize your data structure here. */
            public MyQueue()
            {

            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                _stack1.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (Empty())
                {
                    return -1;
                }
                if (_stack2.Count > 0)
                {
                    return _stack2.Pop();
                }
                while (_stack1.Count > 1)
                {
                    _stack2.Push(_stack1.Pop());
                }
                return _stack1.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (Empty())
                {
                    return -1;
                }
                if (_stack2.Count == 0)
                {
                    while (_stack1.Count > 0)
                    {
                        _stack2.Push(_stack1.Pop());
                    }
                }
                return _stack2.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return _stack1.Count == 0 && _stack2.Count == 0;
            }
        }
    }
}
