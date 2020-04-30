using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A309 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                int dp0 = 0;
                int dp1 = int.MinValue;
                int prev = 0;
                for (int i = 0; i < prices.Length; i++)
                {
                    var temp = dp0;
                    dp0 = Math.Max(dp0, dp1 + prices[i]);
                    dp1 = Math.Max(dp1, prev - prices[i]);
                    prev = temp;
                }
                return dp0;
            }
        }
    }
}
