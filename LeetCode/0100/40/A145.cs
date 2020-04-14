using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LeetCode._0100._40
{
    class A145 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，返回它的 后序 遍历。

        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();
            TreeNode prev = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Peek();
                if (root.right != null && root.right != prev)
                {
                    root = root.right;
                }
                else
                {
                    ans.Add(root.val);
                    stack.Pop();
                    prev = root;
                    root = null;
                }
            }
            return ans;
        }

        public IList<int> PostorderTraversal_1(TreeNode root)
        {
            List<int> ans = new List<int>();
            if (root == null)
            {
                return ans;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                var node = stack.Peek();
                if (node == null)
                {
                    stack.Pop();
                    node = stack.Pop();
                    ans.Add(node.val);
                    continue;
                }
                stack.Push(null);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return ans;
        }
    }
}
