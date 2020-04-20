using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A238 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums;
            }
            int[] ans = new int[nums.Length];
            int m = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = m;
                m *= nums[i];
            }

            m = 1;
            for (int i = nums.Length - 1 ; i >= 0; i--)
            {
                ans[i] *= m;
                m *= nums[i];
            }
            return ans;
        }
    }
}
