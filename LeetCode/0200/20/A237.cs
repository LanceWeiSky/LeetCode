using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A237 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public void DeleteNode(ListNode node)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }
        }
    }
}
