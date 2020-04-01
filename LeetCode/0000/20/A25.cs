using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A25 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。

        //k 是一个正整数，它的值小于或等于链表的长度。

        //如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。



        //示例：

        //给你这个链表：1->2->3->4->5

        //当 k = 2 时，应当返回: 2->1->4->3->5

        //当 k = 3 时，应当返回: 3->2->1->4->5

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/reverse-nodes-in-k-group
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var prev = dummy;
            var next = prev;
            while(prev != null)
            {
                var start = prev.next;
                var end = start;
                for (int i = 1; i < k && end != null; i++)
                {
                    end = end.next;
                }
                if(end == null)
                {
                    break;
                }
                next = end.next;
                end.next = null;
                Reverse(start);
                start.next = next;
                prev.next = end;
                prev = start;
            }
            return dummy.next;
        }

        private void Reverse(ListNode node)
        {
            ListNode prev = null;
            while(node != null)
            {
                var temp = node.next;
                node.next = prev;
                prev = node;
                node = temp;
            }
        }
    }
}
