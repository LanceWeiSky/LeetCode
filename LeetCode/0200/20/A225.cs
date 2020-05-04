using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A225 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyStack
        {

            private readonly Queue<int> _queue = new Queue<int>();

            /** Initialize your data structure here. */
            public MyStack()
            {

            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                _queue.Enqueue(x);
                var count = _queue.Count;
                for (int i = 1; i < count; i++)
                {
                    _queue.Enqueue(_queue.Dequeue());
                }
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return _queue.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return _queue.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return _queue.Count == 0;
            }
        }
    }
}
