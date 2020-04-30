using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A378 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int KthSmallest(int[][] matrix, int k)
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
                int left = matrix[0][0];
                int right = matrix[rows - 1][cols - 1];
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (NoMoreThanCount(matrix, mid) < k)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return left;
            }

            private int NoMoreThanCount(int[][] matrix, int value)
            {
                int rows = matrix.Length;
                int cols = matrix[0].Length;
                int row = rows - 1;
                int col = 0;
                int count = 0;
                while (row >= 0 && col < cols)
                {
                    if (matrix[row][col] <= value)
                    {
                        count += row + 1;
                        col++;
                    }
                    else
                    {
                        row--;
                    }
                }
                return count;
            }
        }
    }
}
