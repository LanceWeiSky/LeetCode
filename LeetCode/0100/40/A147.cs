using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A147 : IQuestion
    {
        public void Run()
        {
            var ans = InsertionSortList(Utility.ConvertToListNode("[3,2,4]"));
        }

        //对链表进行插入排序。

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            while (head != null)
            {
                var sorted = dummy;
                while (sorted.next != null && sorted.next != head)
                {
                    if (head.val <= sorted.next.val)
                    {
                        break;
                    }
                    sorted = sorted.next;
                }
                if (sorted.next == head)
                {
                    var temp = head.next;
                    head.next = null;
                    head = temp;
                }
                else
                {
                    var temp = head;
                    head = head.next;
                    temp.next = sorted.next;
                    sorted.next = temp;
                }
            }
            return dummy.next;
        }
    }
}
