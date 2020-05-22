using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._80
{
    class A498 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] FindDiagonalOrder(int[][] matrix)
            {
                int rows = matrix.Length;
                if (rows == 0)
                {
                    return new int[0];
                }
                int cols = matrix[0].Length;
                if (cols == 0)
                {
                    return new int[0];
                }
                int row = 0, col = 0;
                int[] ans = new int[rows * cols];
                int index = 0;
                bool up = true;
                while (index < ans.Length)
                {
                    ans[index++] = matrix[row][col];
                    if (up)
                    {
                        if (col == cols - 1)
                        {
                            up = false;
                            row++;
                        }
                        else if (row == 0)
                        {
                            up = false;
                            col++;
                        }
                        else
                        {
                            row--;
                            col++;
                        }
                    }
                    else
                    {
                        if (row == rows - 1)
                        {
                            up = true;
                            col++;
                        }
                        else if (col == 0)
                        {
                            up = true;
                            row++;
                        }
                        else
                        {
                            row++;
                            col--;
                        }
                    }
                }
                return ans;
            }
        }
    }
}
