using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A213 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int prev1 = 0;
            int prev2 = 0;
            int curr1 = 0;
            int curr2 = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var temp = curr1;
                curr1 = Math.Max(curr1, prev1 + nums[i]);
                prev1 = temp;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                var temp = curr2;
                curr2 = Math.Max(curr2, prev2 + nums[i]);
                prev2 = temp;
            }

            return Math.Max(curr1, curr2);
        }


    }
}
