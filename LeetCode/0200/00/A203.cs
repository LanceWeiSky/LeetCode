using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A203 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            var p = dummy;
            while (p.next != null)
            {
                if (p.next.val == val)
                {
                    p.next = p.next.next;
                }
                else
                {
                    p = p.next;
                }
            }
            return dummy.next;
        }
    }
}
