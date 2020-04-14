using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A445 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }
            Stack<int> result = new Stack<int>();
            int carry = 0;
            while (s1.Count > 0 || s2.Count > 0)
            {
                int v1 = 0;
                int v2 = 0;
                if (s1.Count > 0)
                { 
                    v1 = s1.Pop();
                }
                if (s2.Count > 0)
                {
                    v2 = s2.Pop();
                }
                int r = v1 + v2 + carry;
                carry = r / 10;
                r = r % 10;
                result.Push(r);
            }
            if (carry > 0)
            {
                result.Push(carry);
            }
            ListNode dummy = new ListNode(0);
            var p = dummy;
            while (result.Count > 0)
            {
                p.next = new ListNode(result.Pop());
                p = p.next;
            }
            return dummy.next;
        }
    }
}
