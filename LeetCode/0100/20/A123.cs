using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeetCode._0100._20
{
    class A123 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。

        //设计一个算法来计算你所能获取的最大利润。你最多可以完成 两笔 交易。

        //注意: 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }
            int max10 = 0;
            int max20 = 0;
            int max11 = int.MinValue;
            int max21 = int.MinValue;
            for (int i = 0; i < prices.Length; i++)
            {
                max20 = Math.Max(max20, max21 + prices[i]);
                max21 = Math.Max(max21, max10 - prices[i]);
                max10 = Math.Max(max10, max11 + prices[i]);
                max11 = Math.Max(max11, -prices[i]);
            }
            return max20;
        }
    }
}
