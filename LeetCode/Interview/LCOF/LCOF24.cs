using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF24 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //定义一个函数，输入一个链表的头节点，反转该链表并输出反转后链表的头节点。

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            var p = head;
            var q = head.next;
            head.next = null;
            while (q != null)
            {
                var temp = q.next;
                q.next = p;
                p = q;
                q = temp;
            }
            return p;
        }
    }
}
