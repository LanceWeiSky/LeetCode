using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1400._20
{
    class A1429 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class FirstUnique
        {
            private readonly Queue<int> _queue = new Queue<int>();
            private readonly HashSet<int> _seen1 = new HashSet<int>();
            private readonly HashSet<int> _seen2 = new HashSet<int>();

            public FirstUnique(int[] nums)
            {
                foreach (var num in nums)
                {
                    Add(num);
                }
            }

            public int ShowFirstUnique()
            {
                while (_queue.Count > 0 && _seen2.Contains(_queue.Peek()))
                {
                    _queue.Dequeue();
                }
                if (_queue.Count == 0)
                {
                    return -1;
                }
                return _queue.Peek();
            }

            public void Add(int value)
            {
                if (_seen1.Add(value))
                {
                    _queue.Enqueue(value);
                }
                else
                {
                    _seen1.Remove(value);
                    _seen2.Add(value);
                }
            }
        }
    }
}
