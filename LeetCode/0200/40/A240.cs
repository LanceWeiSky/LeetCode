using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A240 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool SearchMatrix(int[,] matrix, int target)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int row = 0;
                int col = cols - 1;
                while (row < rows && col >= 0)
                {
                    if (matrix[row, col] == target)
                    {
                        return true;
                    }
                    else if (matrix[row, col] > target)
                    {
                        col--;
                    }
                    else
                    {
                        row++;
                    }
                }
                return false;
            }
        }
    }
}
