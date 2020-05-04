using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A430 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }


        public class Solution
        {
            public Node Flatten(Node head)
            {
                if (head == null)
                {
                    return null;
                }
                Stack<Node> stack = new Stack<Node>();
                var p = head;
                Node prev = null;
                while (stack.Count > 0 || p != null)
                {
                    while (p != null)
                    {
                        if (p.child != null)
                        {
                            if (p.next != null)
                            {
                                stack.Push(p.next);
                            }
                            p.next = p.child;
                            p.child = null;
                        }
                        p.prev = prev;
                        prev = p;
                        p = p.next;
                    }

                    if (stack.Count > 0)
                    {
                        p = stack.Pop();
                        prev.next = p;
                        p.prev = prev;
                    }
                }
                return head;
            }
        }
    }
}
