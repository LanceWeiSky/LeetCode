using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A285 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
            {
                if (root == null)
                {
                    return null;
                }
                bool found = false;
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while (root != null || stack.Count > 0)
                {
                    while (root != null)
                    {
                        stack.Push(root);
                        root = root.left;
                    }

                    root = stack.Pop();
                    if (found)
                    {
                        return root;
                    }
                    if (root.val == p.val)
                    {
                        found = true;
                    }
                    root = root.right;
                }
                return null;
            }
        }
    }
}
