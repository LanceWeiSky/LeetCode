using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A368 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return new List<int>();
                }
                Array.Sort(nums);
                int max = 0;
                int maxIndex = 0;
                int[,] dp = new int[nums.Length, 2];
                for (int i = 0; i < nums.Length; i++)
                {
                    dp[i, 0] = 1;
                    dp[i, 1] = -1;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (nums[i] % nums[j] == 0 && dp[j, 0] >= dp[i, 0])
                        {
                            dp[i, 0] = dp[j, 0] + 1;
                            dp[i, 1] = j;
                        }
                    }
                    if (dp[i, 0] > max)
                    {
                        max = dp[i, 0];
                        maxIndex = i;
                    }
                }
                List<int> ans = new List<int>();
                while (maxIndex >= 0)
                {
                    ans.Add(nums[maxIndex]);
                    maxIndex = dp[maxIndex, 1];
                }
                ans.Reverse();
                return ans;
            }
        }
    }
}
