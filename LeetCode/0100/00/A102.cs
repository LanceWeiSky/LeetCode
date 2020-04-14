using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A102 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）。

        public IList<IList<int>> LevelOrder(TreeNode root)
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
            return ans;
        }
    }
}
