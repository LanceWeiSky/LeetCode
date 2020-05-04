using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A235 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                while (root != null)
                {
                    if (p.val > root.val && q.val > root.val)
                    {
                        root = root.right;
                    }
                    else if (p.val < root.val && q.val < root.val)
                    {
                        root = root.left;
                    }
                    else
                    {
                        return root;
                    }
                }
                return null;
            }
        }
    }
}
