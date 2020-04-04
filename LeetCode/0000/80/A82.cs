using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A82 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            var cur = dummy;
            while (cur.next != null && cur.next.next != null)
            {
                if (cur.next.val == cur.next.next.val)
                {
                    int v = cur.next.val;
                    var temp = cur.next;
                    while (temp != null && temp.val == v)
                    {
                        temp = temp.next;
                    }
                    cur.next = temp;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return dummy.next;
        }
    }
}
