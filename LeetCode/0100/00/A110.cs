using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A110 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，判断它是否是高度平衡的二叉树。
        //本题中，一棵高度平衡二叉树定义为：
        //一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过1。

        public bool IsBalanced(TreeNode root)
        {
            return IsBalanced(root, out _);
        }

        private bool IsBalanced(TreeNode node, out int height)
        {
            height = 0;
            if (node == null)
            {
                return true;
            }

            if (!IsBalanced(node.left, out var lh))
            {
                return false;
            }

            if (!IsBalanced(node.right, out var rh))
            {
                return false;
            }

            height = Math.Max(lh, rh) + 1;
            return Math.Abs(lh - rh) < 2;
        }
    }
}
