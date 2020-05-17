using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._20
{
    class A622 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyCircularQueue
        {

            private readonly int[] _nums;
            private int _front;
            private int _rear;

            /** Initialize your data structure here. Set the size of the queue to be k. */
            public MyCircularQueue(int k)
            {
                _nums = new int[k + 1];
            }

            /** Insert an element into the circular queue. Return true if the operation is successful. */
            public bool EnQueue(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                _nums[_rear] = value;
                _rear = (_rear + 1) % _nums.Length;
                return true;
            }

            /** Delete an element from the circular queue. Return true if the operation is successful. */
            public bool DeQueue()
            {
                if (IsEmpty())
                {
                    return false;
                }
                _front = (_front + 1) % _nums.Length;
                return true;
            }

            /** Get the front item from the queue. */
            public int Front()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return _nums[_front];
            }

            /** Get the last item from the queue. */
            public int Rear()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                if (_rear == 0)
                {
                    return _nums[_nums.Length - 1];
                }
                return _nums[_rear - 1];
            }

            /** Checks whether the circular queue is empty or not. */
            public bool IsEmpty()
            {
                return _front == _rear;
            }

            /** Checks whether the circular queue is full or not. */
            public bool IsFull()
            {
                return (_rear + 1) % _nums.Length == _front;
            }
        }
    }
}
