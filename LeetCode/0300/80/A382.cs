using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A382 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {

            private readonly ListNode _head;
            private readonly Random _rnd = new Random();

            /** @param head The linked list's head.
                Note that the head is guaranteed to be not null, so it contains at least one node. */
            public Solution(ListNode head)
            {
                _head = head;
            }

            /** Returns a random node's value. */
            public int GetRandom()
            {
                var p = _head;
                int count = 0;
                int reserve = 0;
                while (p != null)
                {
                    count++;
                    if (_rnd.Next(count) == 0)
                    {
                        reserve = p.val;
                    }
                    p = p.next;
                }
                return reserve;
            }
        }
    }
}
