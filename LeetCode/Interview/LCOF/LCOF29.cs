using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF29 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字。

        public class Solution
        {
            public int[] SpiralOrder(int[][] matrix)
            {
                if (matrix == null)
                {
                    return new int[0];
                }
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
                bool[][] temp = new bool[rows][];
                for (int i = 0; i < rows; i++)
                {
                    temp[i] = new bool[cols];
                }
                int[] ans = new int[rows * cols];
                int row = 0;
                int col = 0;
                int index = 0;
                int orientation = 0;
                while (index < ans.Length)
                {
                    ans[index] = matrix[row][col];
                    temp[row][col] = true;
                    index++;
                    if (orientation == 0)
                    {
                        if (col < cols - 1 && !temp[row][col + 1])
                        {
                            col++;
                        }
                        else
                        {
                            orientation = 1;
                            row++;
                        }
                    }
                    else if (orientation == 1)
                    {
                        if (row < rows - 1 && !temp[row + 1][col])
                        {
                            row++;
                        }
                        else
                        {
                            orientation = 2;
                            col--;
                        }
                    }
                    else if (orientation == 2)
                    {
                        if (col > 0 && !temp[row][col - 1])
                        {
                            col--;
                        }
                        else
                        {
                            orientation = 3;
                            row--;
                        }
                    }
                    else if (orientation == 3)
                    {
                        if (row > 0 && !temp[row - 1][col])
                        {
                            row--;
                        }
                        else
                        {
                            orientation = 0;
                            col++;
                        }
                    }
                }
                return ans;
            }
        }
    }
}
