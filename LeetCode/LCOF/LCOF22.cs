using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF22 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个链表，输出该链表中倒数第k个节点。为了符合大多数人的习惯，本题从1开始计数，即链表的尾节点是倒数第1个节点。
        //例如，一个链表有6个节点，从头节点开始，它们的值依次是1、2、3、4、5、6。这个链表的倒数第3个节点是值为4的节点。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //双指针，一个指针在前，一个指针在后，相差k个位置，当前面的指针到终点时，后面的指针就是倒数第k个节点

        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            ListNode ans = head;
            for (int i = 0; i < k; i++)
            {
                head = head.next;
            }
            while (head != null)
            {
                head = head.next;
                ans = ans.next;
            }
            return ans;
        }
    }
}
