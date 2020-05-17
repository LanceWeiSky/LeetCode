using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Deque<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();
        private readonly LinkedListNode<T> _head;
        private readonly LinkedListNode<T> _tail;

        public int Count { get; private set; }

        public Deque()
        {
            _head = _list.AddFirst(default(T));
            _tail = _list.AddLast(default(T));

        }

        public void Enqueue(T item)
        {
            _list.AddBefore(_tail, item);
            Count++;
        }

        public T PeekFront()
        {
            return _head.Next.Value;
        }

        public T PeekEnd()
        {
            return _tail.Previous.Value;
        }

        public T DequeueFront()
        {
            if (Count > 0)
            {
                var item = _head.Next;
                _list.Remove(item);
                Count--;
                return item.Value;
            }
            return default;
        }

        public T DequeueEnd()
        {
            if (Count > 0)
            {
                var item = _tail.Previous;
                _list.Remove(item);
                Count--;
                return item.Value;
            }
            return default;
        }
    }
}
