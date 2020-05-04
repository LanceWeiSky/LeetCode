using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0400._80
{
    class A494 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FindTargetSumWays(int[] nums, int S)
            {
                int sum = nums.Sum();
                var p = sum + S;
                if ((p & 1) == 1 || sum < S)
                { 
                    return 0;
                }
                p /= 2;
                int[] dp = new int[p + 1];
                dp[0] = 1;
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = p; j >= nums[i]; j--)
                    {
                        dp[j] += dp[j - nums[i]];
                    }
                }
                return dp[p];
            }
        }
    }
}
