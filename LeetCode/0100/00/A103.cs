using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A103 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
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
                if (ans.Count % 2 == 1)
                {
                    temp.Reverse();
                }
                ans.Add(temp);
            }
            return ans;
        }
    }
}
