using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A99 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //二叉搜索树中的两个节点被错误地交换。
        //请在不改变其结构的情况下，恢复这棵树。

        public void RecoverTree(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode x = null;
            TreeNode y = null;
            TreeNode pre = null;
            var p = root;
            while (stack.Count > 0 || p != null)
            {
                while (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }

                p = stack.Pop();
                if (pre != null && p.val < pre.val)
                {
                    y = p;
                    if (x == null)
                    {
                        x = pre;
                    }
                    else
                    {
                        break;
                    }
                }

                pre = p;
                p = p.right;
            }

            var temp = x.val;
            x.val = y.val;
            y.val = temp;
        }
    }
}
