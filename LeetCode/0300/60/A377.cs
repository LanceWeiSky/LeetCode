using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A377 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CombinationSum4(int[] nums, int target)
            {
                int[] dp = new int[target + 1];
                dp[0] = 1;
                for (int i = 1; i <= target; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] <= i)
                        {
                            dp[i] += dp[i - nums[j]];
                        }
                    }
                }
                return dp[target];
            }
        }
    }
}
