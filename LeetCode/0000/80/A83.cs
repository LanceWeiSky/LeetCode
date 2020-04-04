using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A83 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var temp = head;
            while (temp != null && temp.next != null)
            {
                if (temp.val == temp.next.val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return head;
        }
    }
}
