using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF63 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //假设把某股票的价格按照时间先后顺序存储在数组中，请问买卖该股票一次可能获得的最大利润是多少？

        public int MaxProfit(int[] prices)
        {
            int min = int.MaxValue;//记录i之前的最小值
            int max = 0;
            for(int i = 0; i < prices.Length; i++)
            {
                //假设第i天卖出，得到一个最大利润prices[i] - min，与历史最大利润max取最大值
                min = Math.Min(prices[i], min);
                max = Math.Max(max, prices[i] - min);
            }
            return max;
        }
    }
}
