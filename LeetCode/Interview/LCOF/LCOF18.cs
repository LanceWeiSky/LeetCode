using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF18 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定单向链表的头指针和一个要删除的节点的值，定义一个函数删除该节点。
        //返回删除后的链表的头节点。

        public ListNode DeleteNode(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            var current = head;
            var parent = dummy;
            while (current != null)
            {
                if (current.val == val)
                {
                    current = current.next;
                    parent.next = current;
                }
                else
                {
                    parent = current;
                    current = current.next;
                }
            }
            return dummy.next;
        }
    }
}
