using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._20
{
    class A337 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int Rob(TreeNode root)
            {
                return RobInternal(root).Max();
            }

            private int[] RobInternal(TreeNode node)
            {
                if(node == null)
                {
                    return new int[2];
                }
                int[] money = new int[2];
                var left = RobInternal(node.left);
                var right = RobInternal(node.right);
                money[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
                money[1] = node.val + left[0] + right[0];
                return money;
            }
        }
    }
}
