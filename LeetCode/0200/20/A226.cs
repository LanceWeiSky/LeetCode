using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A226 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return null;
                }
                var temp = root.left;
                root.left = InvertTree(root.right);
                root.right = InvertTree(temp);
                return root;
            }
        }
    }
}
