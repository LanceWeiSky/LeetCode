using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF32_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //从上到下打印出二叉树的每个节点，同一层的节点按照从左到右的顺序打印。

        //广度优先遍历
        public int[] LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }
            List<int> ans = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                ans.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            return ans.ToArray();
        }
    }
}
