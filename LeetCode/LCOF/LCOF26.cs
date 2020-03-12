using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF26 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入两棵二叉树A和B，判断B是不是A的子结构。(约定空树不是任意一个树的子结构)
        //B是A的子结构， 即 A中有出现和B相同的结构和节点值。


        public class Solution
        {
            public bool IsSubStructure(TreeNode A, TreeNode B)
            {
                if (A == null || B == null)
                {
                    return false;
                }
                return SearchRoot(A, B);
            }

            private bool SearchRoot(TreeNode A, TreeNode B)
            {
                if (A == null)
                {
                    return false;
                }
                if (IsSame(A, B))
                {
                    return true;
                }
                return SearchRoot(A.left, B) || SearchRoot(A.right, B);
            }

            private bool IsSame(TreeNode A, TreeNode B)
            {
                if (A == null && B == null)
                {
                    return true;
                }
                else if (A == null && B != null)
                {
                    return false;
                }
                else if (A != null && B == null)
                {
                    return true;
                }
                else if (A.val != B.val)
                {
                    return false;
                }
                return IsSame(A.left, B.left) && IsSame(A.right, B.right);
            }
        }
    }
}
