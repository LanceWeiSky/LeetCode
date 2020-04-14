using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A109 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个单链表，其中的元素按升序排序，将其转换为高度平衡的二叉搜索树。

        //本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/convert-sorted-list-to-binary-search-tree
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public TreeNode SortedListToBST(ListNode head)
        {
            List<int> nums = new List<int>();
            while (head != null)
            {
                nums.Add(head.val);
                head = head.next;
            }

            return BuildTree(nums, 0, nums.Count - 1);
        }

        private TreeNode BuildTree(List<int> nums, int l, int r)
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
