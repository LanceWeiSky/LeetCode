using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A148 : IQuestion
    {
        public void Run()
        {
            var ans = SortList(Utility.ConvertToListNode("[-1,5,3,4,0]"));
        }

        //在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序。

        public ListNode SortList(ListNode head)
        {
            int length = 0;
            var p = head;
            while (p != null)
            {
                p = p.next;
                length++;
            }
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            for (int i = 1; i < length; i *= 2)
            {
                var prev = dummy;
                var cur = prev.next;
                while (cur != null)
                {
                    var first = cur;
                    for (int j = 0; j < i - 1 && cur != null; j++)
                    {
                        cur = cur.next;
                    }
                    if (cur == null)
                    {
                        break;
                    }

                    var second = cur.next;
                    cur.next = null;
                    cur = second;
                    for (int j = 0; j < i - 1 && cur != null; j++)
                    {
                        cur = cur.next;
                    }

                    ListNode remain = null;
                    if (cur != null)
                    {
                        remain = cur.next;
                        cur.next = null;
                    }
                    cur = remain;

                    var temp = Merge(first, second, out var tail);
                    prev.next = temp;
                    prev = tail;
                    tail.next = remain;
                }
            }
            return dummy.next;
        }

        private ListNode Merge(ListNode node1, ListNode node2, out ListNode tail)
        {
            ListNode dummy = new ListNode(0);
            var p = dummy;
            while (node1 != null && node2 != null)
            {
                if (node1.val < node2.val)
                {
                    p.next = node1;
                    node1 = node1.next;
                }
                else
                {
                    p.next = node2;
                    node2 = node2.next;
                }
                p = p.next;
            }

            while (node1 != null)
            {
                p.next = node1;
                node1 = node1.next;
                p = p.next;
            }
            while (node2 != null)
            {
                p.next = node2;
                node2 = node2.next;
                p = p.next;
            }
            tail = p;
            return dummy.next;
        }
    }
}
