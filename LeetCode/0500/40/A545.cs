using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A545 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> BoundaryOfBinaryTree(TreeNode root)
            {
                List<int> res = new List<int>();
                DFS(root, true, true, res);
                return res;
            }

            private void DFS(TreeNode node, bool isLeftBoundary, bool isRightBoundary, List<int> res)
            {
                if (node == null)
                {
                    return;
                }
                if (isLeftBoundary)
                {
                    res.Add(node.val);
                }
                else if (node.left == null && node.right == null)
                {
                    res.Add(node.val);
                    return;
                }
                DFS(node.left, isLeftBoundary, !isLeftBoundary && isRightBoundary && node.right == null, res);
                DFS(node.right, !isRightBoundary && isLeftBoundary && node.left == null, isRightBoundary, res);
                if (isRightBoundary && !isLeftBoundary)
                {
                    res.Add(node.val);
                }
            }
        }
    }
}
