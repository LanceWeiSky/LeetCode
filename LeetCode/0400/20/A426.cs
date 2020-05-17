using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A426 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public Node TreeToDoublyList(Node root)
            {
                if (root == null)
                {
                    return null;
                }
                Node first = null;
                Node last = null;
                Stack<Node> stack = new Stack<Node>();
                while (root != null || stack.Count > 0)
                {
                    while (root != null)
                    {
                        stack.Push(root);
                        root = root.left;
                    }

                    root = stack.Pop();
                    var right = root.right;
                    if (last == null)
                    {
                        first = root;
                    }
                    else
                    {
                        last.right = root;
                        root.left = last;
                    }
                    last = root;
                    root = right;
                }
                first.left = last;
                last.right = first;
                return first;
            }
        }
    }
}
