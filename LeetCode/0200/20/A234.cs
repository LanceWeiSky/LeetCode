using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A234 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsPalindrome(ListNode head)
            {
                if (head == null)
                {
                    return true;
                }
                var slow = head;
                var fast = head;
                while (fast.next != null && fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                var p1 = head;
                var p2 = ReverseList(slow.next);
                bool result = true;
                while (p2 != null)
                {
                    if (p1.val != p2.val)
                    {
                        result = false;
                        break;
                    }
                    p1 = p1.next;
                    p2 = p2.next;
                }
                fast = ReverseList(fast);
                slow.next = fast;
                return result;
            }

            private ListNode ReverseList(ListNode node)
            {
                ListNode prev = null;
                while (node != null)
                {
                    var next = node.next;
                    node.next = prev;
                    prev = node;
                    node = next;
                }
                return prev;
            }
        }
    }
}
