using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A188 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int MaxProfit(int k, int[] prices)
        {
            if (k > prices.Length / 2)
            {
                int max = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    var temp = prices[i] - prices[i - 1];
                    if(temp > 0)
                    {
                        max += temp;
                    }
                }
                return max;
            }
            int[,] dp = new int[k + 1, 2];
            for (int i = 0; i <= k; i++)
            {
                dp[i, 0] = 0;
                dp[i, 1] = int.MinValue;
            }
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = k; j > 0; j--)
                {
                    dp[j, 0] = Math.Max(dp[j, 0], dp[j, 1] + prices[i]);
                    dp[j, 1] = Math.Max(dp[j, 1], dp[j - 1, 0] - prices[i]);
                }
            }
            return dp[k, 0];
        }
    }
}
