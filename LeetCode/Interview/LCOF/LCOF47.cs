using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF47 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //在一个 m*n 的棋盘的每一格都放有一个礼物，每个礼物都有一定的价值（价值大于 0）。
        //你可以从棋盘的左上角开始拿格子里的礼物，并每次向右或者向下移动一格、直到到达棋盘的右下角。
        //给定一个棋盘及其上面的礼物的价值，请计算你最多能拿到多少价值的礼物？

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/li-wu-de-zui-da-jie-zhi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //由于第一行只能由左向右移动，第一列只能从上到下移动，所以先计算第一列和第一行的和值。
        //其他位置有两种情况，当前位置是从上面移动过来的，或者是从左边移动过来的，当前位置的最大值也就相当于取左边位置和上面位置的最大值与当前位置的值相加
        //计算之后的最后一行，最后一列就是礼物最大值

        public int MaxValue(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            for (int i = 1; i < rows; i++)
            {
                grid[i][0] += grid[i - 1][0];
            }
            for (int i = 1; i < cols; i++)
            {
                grid[0][i] += grid[0][i - 1];
            }
            for (int col = 1; col < cols; col++)
            {
                for (int row = 1; row < rows; row++)
                {
                    grid[row][col] += Math.Max(grid[row][col - 1], grid[row - 1][col]);
                }
            }
            return grid[rows - 1][cols - 1];
        }
    }
}
