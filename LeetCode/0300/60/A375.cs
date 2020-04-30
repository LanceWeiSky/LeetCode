using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A375 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int GetMoneyAmount(int n)
            {
                int[,] dp = new int[n + 2, n + 2];
                for (int len = 2; len <= n; len++)
                {
                    for(int i = 1; i <= n - len + 1; i++)
                    {
                        int end = len + i - 1;
                        dp[i, end] = int.MaxValue;
                        for (int k = i; k <= end; k++)
                        {
                            dp[i, end] = Math.Min(dp[i, end], k + Math.Max(dp[i, k - 1], dp[k + 1, end]));
                        }
                    }
                }
                return dp[1, n];
            }
        }
    }
}
