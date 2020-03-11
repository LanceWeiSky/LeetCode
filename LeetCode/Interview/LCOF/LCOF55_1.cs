using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF55_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一棵二叉树的根节点，求该树的深度。从根节点到叶节点依次经过的节点（含根、叶节点）形成树的一条路径，最长路径的长度为树的深度。

        //层次遍历，获取最大深度
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int ans = 0;
            while (queue.Count > 0)
            {
                ans++;
                int c = queue.Count;
                for (int i = 0; i < c; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return ans;
        }
    }
}
