using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A108 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。
        //本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return BuildTree(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildTree(int[] nums, int l, int r)
        {
            if (l > r)
            {
                return null;
            }
            var mid = (l + r) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = BuildTree(nums, l, mid - 1);
            node.right = BuildTree(nums, mid + 1, r);
            return node;
        }
    }
}
