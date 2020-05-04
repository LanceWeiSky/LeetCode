using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0400._00
{
    class A416 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().CanPartition(new int[] { 1, 2, 5 });
        }

        public class Solution
        {
            public bool CanPartition(int[] nums)
            {
                if (nums.Length < 2)
                {
                    return false;
                }
                int sum = nums.Sum();
                if ((sum & 1) == 1)
                {
                    return false;
                }
                sum /= 2;

                bool[] dp = new bool[sum + 1];
                dp[0] = true;
                if (nums[0] <= sum)
                {
                    dp[nums[0]] = true;
                }
                for(int i = 1; i < nums.Length; i++)
                {
                    for (int j = sum; j >= nums[i]; j--)
                    {
                        if (dp[sum])
                        {
                            return true;
                        }
                        dp[j] = dp[j] || dp[j - nums[i]];
                    }
                }
                return dp[sum];
            }
        }
    }
}
