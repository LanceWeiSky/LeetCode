using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A404 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int SumOfLeftLeaves(TreeNode root)
            {
                int ans = 0;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (stack.Count > 0 || root != null)
                {
                    bool flag = false;
                    while (root != null)
                    {
                        stack.Push(root);
                        if (flag && root.left == null && root.right == null)
                        {
                            ans += root.val;
                        }
                        root = root.left;
                        flag = true;
                    }

                    root = stack.Pop();
                    root = root.right;
                }
                return ans;
            }
        }
    }
}
