using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A143 : IQuestion
    {
        public void Run()
        {
            ReorderList(Utility.ConvertToListNode("[1,2,3,4,5]"));
        }

        //给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
        //将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…

        //你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/reorder-list
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public void ReorderList(ListNode head)
        {
            var n1 = head;
            var n2 = head;
            while (n2 != null && n2.next != null)
            {
                n1 = n1.next;
                n2 = n2.next.next;
            }
            if (n1 == n2)
            {
                return;
            }
            n2 = n1.next;
            n1.next = null;
            n1 = head;
            n2 = Reverse(n2);
            while (n1 != null && n2 != null)
            {
                var temp = n1.next;
                n1.next = n2;
                n2 = n2.next;
                n1.next.next = temp;
                n1 = temp;
            }
        }

        private ListNode Reverse(ListNode node)
        {
            if(node == null)
            {
                return null;
            }
            ListNode prev = null;
            while (node != null)
            {
                var temp = node.next;
                node.next = prev;
                prev = node;
                node = temp;
            }
            return prev;
        }
    }
}
