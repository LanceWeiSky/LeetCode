using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A92 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。

        //说明:
        //1 ≤ m ≤ n ≤ 链表长度。

        //示例:

        //输入: 1->2->3->4->5->NULL, m = 2, n = 4
        //输出: 1->4->3->2->5->NULL

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/reverse-linked-list-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            head = dummy;
            var parent = head;
            for (int i = 0; i < m; i++)
            {
                if (head == null)
                {
                    break;
                }
                parent = head;
                head = head.next;
            }

            var current = head;
            var next = current.next;
            for (int i = m; i < n; i++)
            {
                var temp = next.next;
                next.next = current;
                current = next;
                next = temp;
            }

            parent.next = current;
            head.next = next;
            return dummy.next;
        }

    }
}
