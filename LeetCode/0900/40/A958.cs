using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._40
{
    class A958 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsCompleteTree(TreeNode root)
            {
                int totalCount = 0;
                int lastNum = 0;
                Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
                queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
                while (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    lastNum = temp.Item2;
                    totalCount++;
                    if(temp.Item1.left != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.left, lastNum * 2));
                    }
                    if (temp.Item1.right != null)
                    {
                        queue.Enqueue(new Tuple<TreeNode, int>(temp.Item1.right, lastNum * 2 + 1));
                    }
                }
                return totalCount == lastNum;
            }
        }
    }
}
