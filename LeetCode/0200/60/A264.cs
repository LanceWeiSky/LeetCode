using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A264 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NthUglyNumber(int n)
            {
                if (n == 1)
                {
                    return 1;
                }
                int[] dp = new int[n];
                dp[0] = 1;
                int p2 = 1;
                int p3 = 1;
                int p5 = 1;
                for (int i = 1; i < n; i++)
                {
                    int v2 = dp[p2] * 2;
                    int v3 = dp[p3] * 3;
                    int v5 = dp[p5] * 5;
                    int min = Math.Min(v2, Math.Min(v3, v5));
                    dp[i] = min;
                    if (min == v2)
                    {
                        p2++;
                    }
                    if (min == v3)
                    {
                        p3++;
                    }
                    if (min == v5)
                    {
                        p5++;
                    }
                }
                return dp[n - 1];
            }
        }
    }
}
