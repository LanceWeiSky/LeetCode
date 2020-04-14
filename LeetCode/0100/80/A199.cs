using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A199 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public IList<int> RightSideView(TreeNode root)
        {
            List<int> ans = new List<int>();
            if (root == null)
            {
                return ans;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (i == 0)
                    {
                        ans.Add(node.val);
                    }
                }
            }
            return ans;
        }
    }
}
