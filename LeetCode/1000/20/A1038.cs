using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1000._20
{
    class A1038 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode BstToGst(TreeNode root)
            {
                if(root == null)
                {
                    return root;
                }
                Stack<TreeNode> stack = new Stack<TreeNode>();
                int sum = 0;
                var p = root;
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
