using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._60
{
    class A572 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsSubtree(TreeNode s, TreeNode t)
            {
                if (IsSameTree(s, t))
                {
                    return true;
                }
                if (s == null)
                {
                    return false;
                }
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
            }

            private bool IsSameTree(TreeNode s, TreeNode t)
            {
                if (s == null && t == null)
                {
                    return true;
                }
                if (s == null || t == null)
                {
                    return false;
                }
                if (s.val != t.val)
                {
                    return false;
                }
                return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
            }
        }
    }
}
