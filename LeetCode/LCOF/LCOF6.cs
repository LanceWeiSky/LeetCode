using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF6 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个链表的头节点，从尾到头反过来返回每个节点的值（用数组返回）。

        public int[] ReversePrint(ListNode head)
        {
            //第一次遍历确定连表长度
            int length = 0;
            var temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }
            //第二次遍历向数组中打印数据（从尾到头）
            int[] ans = new int[length];
            temp = head;
            while (temp != null)
            {
                ans[length - 1] = temp.val;
                temp = temp.next;
                length--;
            }
            return ans;
        }
    }
}
