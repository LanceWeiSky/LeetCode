using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A160 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //编写一个程序，找到两个单链表相交的起始节点。

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var node1 = headA;
            var node2 = headB;
            while (node1 != node2)
            {
                node1 = node1 == null ? headB : node1.next;
                node2 = node2 == null ? headA : node2.next;
            }
            return node1;
        }
    }
}
