using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF28 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请实现一个函数，用来判断一棵二叉树是不是对称的。如果一棵二叉树和它的镜像一样，那么它是对称的。

        public class Solution
        {
            public bool IsSymmetric(TreeNode root)
            {
                if (root == null)
                {
                    return true;
                }
                return IsSymmetric(root.left, root.right);
            }

            private bool IsSymmetric(TreeNode left, TreeNode right)
            {
                if (left == null && right == null)
                {
                    return true;
                }
                else if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }
                return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
            }
        }
    }
}
