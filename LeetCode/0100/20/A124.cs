using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A124 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非空二叉树，返回其最大路径和。
        //本题中，路径被定义为一条从树中任意节点出发，达到任意节点的序列。该路径至少包含一个节点，且不一定经过根节点。

        private int _max = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumInternal(root);
            return _max;
        }

        private int MaxPathSumInternal(TreeNode node)
        {
            if(node == null)
            {
                return 0;
            }
            var left = Math.Max(MaxPathSumInternal(node.left), 0);
            var right = Math.Max(MaxPathSumInternal(node.right), 0);

            _max = Math.Max(_max, left + right + node.val);

            return Math.Max(left, right) + node.val;
        }
    }
}
