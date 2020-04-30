using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A328 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public ListNode OddEvenList(ListNode head)
            {
                if (head == null)
                {
                    return null;
                }
                ListNode p = head;
                ListNode q = new ListNode(0);
                ListNode head2 = q;
                ListNode prev = p;
                while (p != null && p.next != null)
                {
                    q.next = p.next;
                    p.next = p.next.next;
                    p = p.next;
                    q = q.next;
                    if (p != null)
                    {
                        prev = p;
                    }
                }
                q.next = null;
                prev.next = head2.next;
                return head;
            }
        }
    }
}
