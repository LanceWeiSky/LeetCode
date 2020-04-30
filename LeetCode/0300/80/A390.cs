using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A390 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LastRemaining_1(int n)
            {
                if (n == 1)
                {
                    return 1;
                }
                return 2 * (n / 2 + 1 - LastRemaining(n / 2));
            }

            public int LastRemaining(int n)
            {
                int[] dp = new int[n + 1];
                dp[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    dp[i] = 2 * (i / 2 + 1 - dp[i / 2]);
                }
                return dp[n];
            }
        }
    }
}
