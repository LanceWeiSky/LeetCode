using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A86 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。
        //你应当保留两个分区中每个节点的初始相对位置。

        public ListNode Partition(ListNode head, int x)
        {
            ListNode n1 = new ListNode(0);
            var d1 = n1;
            ListNode n2 = new ListNode(0);
            var d2 = n2;
            while (head != null)
            {
                if (head.val < x)
                {
                    n1.next = head;
                    n1 = n1.next;
                }
                else
                {
                    n2.next = head;
                    n2 = n2.next;
                }
                head = head.next;
            }
            n2.next = null;
            n1.next = d2.next;
            return d1.next;
        }
    }
}
