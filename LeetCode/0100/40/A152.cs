using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A152 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个整数数组 nums ，请你找出数组中乘积最大的连续子数组（该子数组中至少包含一个数字）。

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int ans = int.MinValue;
            int max = 1;
            int min = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    var temp = max;
                    max = min;
                    min = temp;
                }
                max = Math.Max(nums[i] * max, nums[i]);
                min = Math.Min(nums[i] * min, nums[i]);

                ans = Math.Max(ans, max);
            }
            return ans;
        }
    }
}
