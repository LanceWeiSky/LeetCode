using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF55_2 : IQuestion
    {
        public void Run()
        {
            string input = "[1,2,2,3,3,null,null,4,4]";
            var root = Utility.ConvertToTreeNode(input);
            var ans = IsBalanced(root);
        }

        //输入一棵二叉树的根节点，判断该树是不是平衡二叉树。如果某二叉树中任意节点的左右子树的深度相差不超过1，那么它就是一棵平衡二叉树。

        public bool IsBalanced(TreeNode root)
        {
            int d = 0;
            return IsBalanced(root, ref d);
        }

        private bool IsBalanced(TreeNode node, ref int depth)
        {
            if (node == null)
            {
                return true;
            }
            int l = 0;
            int r = 0;
            var flag = IsBalanced(node.left, ref l) && IsBalanced(node.right, ref r) && Math.Abs(l - r) < 2;
            if (flag)
            {
                depth = Math.Max(l, r) + 1;
            }
            return flag;
        }
    }
}
