using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A111 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，找出其最小深度。
        //最小深度是从根节点到最近叶子节点的最短路径上的节点数量。
        //说明: 叶子节点是指没有子节点的节点。

        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int ans = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                ans++;
                int c = queue.Count;
                for (int i = 0; i < c; i++)
                {
                    var n = queue.Dequeue();
                    if (n.left == null && n.right == null)
                    {
                        return ans;
                    }
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                }
            }
            return ans;
        }
    }
}
