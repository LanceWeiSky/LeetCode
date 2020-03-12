using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF42 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个整型数组，数组里有正数也有负数。数组中的一个或连续多个整数组成一个子数组。求所有子数组的和的最大值。
        //要求时间复杂度为O(n)。

        public int MaxSubArray(int[] nums)
        {
            int ans = nums[0];
            int sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //如果前面子数组的和加当前元素比当前元素还小，则舍弃前面子数组
                sum = Math.Max(sum + nums[i], nums[i]);
                if (sum > ans)
                {
                    ans = sum;
                }
            }
            return ans;
        }
    }
}
