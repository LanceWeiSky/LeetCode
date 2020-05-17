using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._40
{
    class A641 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyCircularDeque
        {
            private readonly int _size;
            private int _count;
            private readonly LinkedList<int> _list = new LinkedList<int>();
            private readonly LinkedListNode<int> _first;
            private readonly LinkedListNode<int> _last;

            /** Initialize your data structure here. Set the size of the deque to be k. */
            public MyCircularDeque(int k)
            {
                _size = k;
                _first = _list.AddFirst(0);
                _last = _list.AddLast(0);
            }

            /** Adds an item at the front of Deque. Return true if the operation is successful. */
            public bool InsertFront(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                _list.AddAfter(_first, value);
                _count++;
                return true;
            }

            /** Adds an item at the rear of Deque. Return true if the operation is successful. */
            public bool InsertLast(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                _list.AddBefore(_last, value);
                _count++;
                return true;
            }

            /** Deletes an item from the front of Deque. Return true if the operation is successful. */
            public bool DeleteFront()
            {
                if (IsEmpty())
                {
                    return false;
                }
                _list.Remove(_first.Next);
                _count--;
                return true;
            }

            /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
            public bool DeleteLast()
            {
                if (IsEmpty())
                {
                    return false;
                }
                _list.Remove(_last.Previous);
                _count--;
                return true;
            }

            /** Get the front item from the deque. */
            public int GetFront()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return _first.Next.Value;
            }

            /** Get the last item from the deque. */
            public int GetRear()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return _last.Previous.Value;
            }

            /** Checks whether the circular deque is empty or not. */
            public bool IsEmpty()
            {
                return _count == 0;
            }

            /** Checks whether the circular deque is full or not. */
            public bool IsFull()
            {
                return _count == _size;
            }
        }
    }
}
