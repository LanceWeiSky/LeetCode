using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A114 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，原地将它展开为链表。

        public void Flatten(TreeNode root)
        {
            var p = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Count > 0 || p != null)
            {
                if (p.left != null)
                {
                    if (p.right != null)
                    {
                        stack.Push(p.right);
                    }
                    p.right = p.left;
                    p.left = null;
                    p = p.right;
                }
                else
                {
                    if (p.right == null && stack.Count > 0)
                    {
                        p.right = stack.Pop();
                    }
                    p = p.right;
                }
            }
        }
    }
}
