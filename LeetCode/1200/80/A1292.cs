using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._80
{
    class A1292 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxSideLength(int[][] mat, int threshold)
            {
                int rows = mat.Length;
                int cols = mat[0].Length;
                int[,] sums = new int[rows + 1, cols + 1];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        sums[row + 1, col + 1] = sums[row, col + 1] + sums[row + 1, col] - sums[row, col] + mat[row][col];
                    }
                }
                int length = 0;
                int max = Math.Min(rows, cols);
                for (int row = 1; row <= rows; row++)
                {
                    for (int col = 1; col <= cols; col++)
                    {
                        for (int l = length + 1; l <= max; l++)
                        {
                            if (row <= rows - l + 1 && col <= cols - l + 1 && GetSum(sums, row, col, l) <= threshold)
                            {
                                length++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                return length;
            }

            private int GetSum(int[,] sums, int row, int col, int length)
            {
                return sums[row + length - 1, col + length - 1] - sums[row - 1, col + length - 1] - sums[row + length - 1, col - 1] + sums[row - 1, col - 1];
            }
        }
    }
}
