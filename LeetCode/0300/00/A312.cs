using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A312 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxCoins(int[] nums)
            {
                int[] nums2 = new int[nums.Length + 2];
                int n = nums2.Length;
                int[,] dp = new int[n, n];
                nums2[0] = 1;
                nums2[n - 1] = 1;
                Array.Copy(nums, 0, nums2, 1, nums.Length);
                for (int i = n - 2; i >= 0; i--)
                {
                    for (int j = i + 2; j < n; j++)
                    {
                        int max = 0;
                        for (int k = i + 1; k < j; k++)
                        {
                            max = Math.Max(dp[i, k] + dp[k, j] + nums2[i] * nums2[j] * nums2[k], max);
                        }
                        dp[i, j] = max;
                    }
                }
                return dp[0, n - 1];
            }
        }
    }
}
