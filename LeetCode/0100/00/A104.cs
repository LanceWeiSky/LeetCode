using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A104 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，找出其最大深度。
        //二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
        //说明: 叶子节点是指没有子节点的节点。

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
