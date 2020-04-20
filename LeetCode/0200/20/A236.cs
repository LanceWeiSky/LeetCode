using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A236 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left == null)
            {
                return right;
            }
            if(right == null)
            {
                return left;
            }
            return root;
        }

    }
}
