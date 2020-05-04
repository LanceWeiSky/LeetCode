using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._00
{
    class A617 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
            {
                if (t1 == null)
                {
                    return t2;
                }
                if (t2 == null)
                {
                    return t1;
                }

                t1.val += t2.val;
                t1.left = MergeTrees(t1.left, t2.left);
                t1.right = MergeTrees(t1.right, t2.right);
                return t1;
            }
        }
    }
}
