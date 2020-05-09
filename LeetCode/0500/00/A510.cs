using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._00
{
    class A510 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node parent;
        }

        public class Solution
        {
            public Node InorderSuccessor(Node x)
            {
                if (x == null)
                {
                    return null;
                }
                if (x.right == null)
                {
                    while (x.parent != null)
                    {
                        if (x.parent.left == x)
                        {
                            return x.parent;
                        }
                        x = x.parent;
                    }
                }
                else
                { 
                    x = x.right;
                    while (x.left != null)
                    {
                        x = x.left;
                    }
                    return x;
                }
                return null;
            }
        }
    }
}
