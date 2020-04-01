using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A64 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
        //说明：每次只能向下或者向右移动一步。

        public int MinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0)
            {
                return 0;
            }
            int cols = grid[0].Length;
            if (cols == 0)
            {
                return 0;
            }
            for (int i = 1; i < cols; i++)
            {
                grid[0][i] += grid[0][i - 1];
            }
            for (int i = 1; i < rows; i++)
            {
                grid[i][0] += grid[i - 1][0];
            }
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    grid[i][j] += Math.Min(grid[i][j - 1], grid[i - 1][j]);
                }
            }
            return grid[rows - 1][cols - 1];
        }
    }
}
