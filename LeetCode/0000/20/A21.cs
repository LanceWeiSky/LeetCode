using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A21 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 

        //示例：

        //输入：1->2->4, 1->3->4
        //输出：1->1->2->3->4->4

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/merge-two-sorted-lists
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var node = dummy;
            while(l1 != null && l2 != null)
            {
                if(l1.val < l2.val)
                {
                    node.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    node.next = l2;
                    l2 = l2.next;
                }
                node = node.next;
            }
            if(l1 == null)
            {
                node.next = l2;
            }
            if(l2 == null)
            {
                node.next = l1;
            }
            return dummy.next;
        }
    }
}
