using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF32_2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //从上到下按层打印二叉树，同一层的节点按从左到右的顺序打印，每一层打印到一行。

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (root == null)
            {
                return ans;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                IList<int> temp = new List<int>(count);
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    temp.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                ans.Add(temp);
            }
            return ans;
        }
    }
}
