using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A206 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            var cur = head;
            while (cur != null)
            {
                var temp = cur.next;
                cur.next = prev;
                prev = cur;
                cur = temp;
            }
            return prev;
        }

        public ListNode ReverseList_1(ListNode head)
        {
            return ReverseInternal(head, null);
        }

        private ListNode ReverseInternal(ListNode head, ListNode prev)
        {
            var node = ReverseInternal(head.next, head);
            head.next = prev;
            return node;
        }
    }
}
