using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A141 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个链表，判断链表中是否有环。

        //为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/linked-list-cycle
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool HasCycle(ListNode head)
        {
            var n1 = head;
            var n2 = head;
            while (true)
            { 
                if(n2 == null || n2.next == null)
                {
                    return false;
                }
                n1 = n1.next;
                n2 = n2.next.next;
                if (n1 == n2)
                {
                    return true;
                }
            }
        }
    }
}
