using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A107 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> ans = new List<IList<int>>();
            if (root == null)
            {
                return ans;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int c = queue.Count;
                List<int> temp = new List<int>(c);
                for (int i = 0; i < c; i++)
                {
                    var n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                    temp.Add(n.val);
                }
                ans.Add(temp);
            }
            ans.Reverse();
            return ans;
        }
    }
}
