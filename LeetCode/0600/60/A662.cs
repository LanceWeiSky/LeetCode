using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._60
{
    class A662 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int WidthOfBinaryTree(TreeNode root)
            {
                int ans = 0;
                if(root == null)
                {
                    return ans;
                }
                Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
                queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
                while (queue.Count > 0)
                {
                    var count = queue.Count;
                    int left = 0;
                    int right = 0;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        if(i == 0)
                        {
                            left = temp.Item2;
                        }
                        if(i == count - 1)
                        {
                            right = temp.Item2;
                        }
                        if(temp.Item1.left != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.left, temp.Item2 * 2));
                        }
                        if (temp.Item1.right != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.right, temp.Item2 * 2 + 1));
                        }
                        ans = Math.Max(right - left + 1, ans);
                    }
                }
                return ans;
            }
        }
    }
}
