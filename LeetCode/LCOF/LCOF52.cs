using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF52 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入两个链表，找出它们的第一个公共节点。

        //思路解析：
        //A和B相连组成新的连表node1，B和A相连组成新的连表node2，同时遍历node1和node2，第一个相同节点就是公共节点
        //例如：
        //A: a1->a2->a3->c1->c2->c3
        //B: b1->b2->c1->c2->c3
        //node1: a1->a2->a3->c1->c2->c3->b1->b2->   c1->c2->c3
        //node2: b1->b2->c1->c2->c3->a1->a2->a3->   c1->c2->c3

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }
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
