using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF25 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入两个递增排序的链表，合并这两个链表并使新链表中的节点仍然是递增排序的。

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);//生成一个哑结点，不需要考虑边界值情况。
            var temp = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    temp.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    temp.next = l1;
                    l1 = l1.next;
                }
                temp = temp.next;
            }
            if (l1 == null)
            {
                temp.next = l2;
            }
            else
            {
                temp.next = l1;
            }
            return dummy.next;
        }
    }
}
