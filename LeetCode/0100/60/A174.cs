using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A174 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int CalculateMinimumHP(int[][] dungeon)
        {
            int rows = dungeon.Length;
            int cols = dungeon[0].Length;
            int[] dp = new int[cols];
            dp[cols - 1] = Math.Max(1, 1 - dungeon[rows - 1][cols - 1]);
            for (int col = cols - 2; col >= 0; col--)
            {
                dp[col] = Math.Max(1, dp[col + 1] - dungeon[rows - 1][col]);
            }
            for (int row = rows - 2; row >= 0; row--)
            {
                dp[cols - 1] = Math.Max(1, dp[cols - 1] - dungeon[row][cols - 1]);
                for (int col = cols - 2; col >= 0; col--)
                {
                    dp[col] = Math.Max(1, Math.Min(dp[col], dp[col + 1]) - dungeon[row][col]);
                }
            }

            return dp[0];
        }

    }
}
