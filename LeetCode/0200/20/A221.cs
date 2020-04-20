using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A221 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int MaximalSquare(char[][] matrix)
        {
            int rows = matrix.Length;
            if (rows == 0)
            {
                return 0;
            }
            int cols = matrix[0].Length;
            if (cols == 0)
            {
                return 0;
            }
            int max = 0;
            int prev = 0;
            int[] dp = new int[cols + 1];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var temp = dp[col + 1];
                    if (matrix[row][col] == '1')
                    {
                        dp[col + 1] = Math.Min(prev, Math.Min(dp[col + 1], dp[col])) + 1;
                    }
                    else
                    {
                        dp[col + 1] = 0;
                    }
                    prev = temp;
                    if (dp[col + 1] > max)
                    {
                        max = dp[col + 1];
                    }
                }
            }
            return max * max;
        }
    }
}
