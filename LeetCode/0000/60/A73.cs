using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A73 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个 m x n 的矩阵，如果一个元素为 0，则将其所在行和列的所有元素都设为 0。请使用原地算法。

        public void SetZeroes(int[][] matrix)
        {
            bool setFirstCol = false;
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for (int r = 0; r < rows; r++)
            {
                if (matrix[r][0] == 0)
                {
                    setFirstCol = true;
                }
                for (int c = 1; c < cols; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[r][0] = 0;
                        matrix[0][c] = 0;
                    }
                }
            }

            for (int c = 1; c < cols; c++)
            {
                if (matrix[0][c] == 0)
                {
                    for (int r = 1; r < rows; r++)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                if (matrix[r][0] == 0)
                {
                    for (int c = 1; c < cols; c++)
                    {
                        matrix[r][c] = 0;
                    }
                }
                else if (setFirstCol)
                {
                    matrix[r][0] = 0;
                }
            }

        }
    }
}
