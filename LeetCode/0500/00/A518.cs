using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._00
{
    class A518 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int Change(int amount, int[] coins)
            {
                int[] dp = new int[amount + 1];
                dp[0] = 1;
                for (int i = 0; i < coins.Length; i++)
                {
                    for (int j = coins[i]; j <= amount; j++)
                    {
                        dp[j] += dp[j - coins[i]];
                    }
                }
                return dp[amount];
            }
        }
    }
}
