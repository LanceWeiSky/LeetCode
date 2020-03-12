using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

        //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

        //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/add-two-numbers
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = null;
            ListNode temp = null;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                if (root == null)
                {
                    root = new ListNode(0);
                    temp = root;
                }
                else
                {
                    temp.next = new ListNode(carry);
                    temp = temp.next;
                    carry = 0;
                }

                if (l1 != null)
                {
                    temp.val += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    temp.val += l2.val;
                    l2 = l2.next;
                }
                if (temp.val > 9)
                {
                    temp.val -= 10;
                    carry = 1;
                }
            }
            if (carry > 0)
            {
                temp.next = new ListNode(carry);
            }
            return root;
        }
    }
}
