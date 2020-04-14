using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A142 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。

        //为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。

        //说明：不允许修改给定的链表。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/linked-list-cycle-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public ListNode DetectCycle(ListNode head)
        {
            var n1 = head;
            var n2 = head;
            while (n2 != null && n2.next != null)
            {
                n1 = n1.next;
                n2 = n2.next.next;
                if (n1 == n2)
                {
                    break;
                }
            }
            if (n2 == null || n2.next == null)
            {
                return null;
            }
            n1 = head;
            while (n1 != n2)
            {
                n1 = n1.next;
                n2 = n2.next;
            }
            return n1;
        }
    }
}
