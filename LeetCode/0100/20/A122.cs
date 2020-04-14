using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A122 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

        //设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。

        //注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MaxProfit(int[] prices)
        {
            int ans = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var temp = prices[i] - prices[i - 1];
                if(temp > 0)
                {
                    ans += temp;
                }
            }
            return ans;
        }
    }
}
