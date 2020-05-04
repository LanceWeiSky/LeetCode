using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A538 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode ConvertBST(TreeNode root)
            {
                if (root == null)
                {
                    return null;
                }
                int sum = 0;
                var p = root;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (stack.Count > 0 || p != null)
                {
                    while (p != null)
                    {
                        stack.Push(p);
                        p = p.right;
                    }

                    p = stack.Pop();
                    sum += p.val;
                    p.val = sum;
                    p = p.left;
                }
                return root;
            }
        }
    }
}
