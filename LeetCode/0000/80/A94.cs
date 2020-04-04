using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A94 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，返回它的中序 遍历。

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();

            var p = root;
            while (stack.Count > 0 || p != null)
            {
                while (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }

                p = stack.Pop();
                ans.Add(p.val);

                p = p.right;
            }

            return ans;
        }
    }
}
