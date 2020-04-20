using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A230 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prev = null;
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                k--;
                if (k == 0)
                {
                    return root.val;
                }
                root = root.right;
            }
            return 0;
        }
    }
}
