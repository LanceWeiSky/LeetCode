using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A144 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，返回它的 前序 遍历。

        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();
            while (root != null)
            {
                if (root.left == null)
                {
                    ans.Add(root.val);
                    root = root.right;
                }
                else
                {
                    var prev = root.left;
                    while (prev.right != null && prev.right != root)
                    {
                        prev = prev.right;
                    }
                    if (prev.right == null)
                    {
                        ans.Add(root.val);
                        prev.right = root;
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                        prev.right = null;
                    }
                }
            }
            return ans;
        }

        public IList<int> PreorderTraversal_1(TreeNode root)
        {
            List<int> ans = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    ans.Add(root.val);
                    root = root.left;
                }

                root = stack.Pop();
                root = root.right;
            }
            return ans;
        }
    }
}
