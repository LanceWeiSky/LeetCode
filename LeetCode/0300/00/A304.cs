using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A304 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class NumMatrix
        {

            private readonly int[,] _cache;

            public NumMatrix(int[][] matrix)
            {
                int rows = matrix.Length;
                if (rows == 0)
                {
                    return;
                }
                int cols = matrix[0].Length;
                if (cols == 0)
                {
                    return;
                }
                _cache = new int[rows + 1, cols + 1];
                for (int row = 0; row < rows; row++)
                {
                    int sum = 0;
                    for (int col = 0; col < cols; col++)
                    {
                        sum += matrix[row][col];
                        _cache[row + 1, col + 1] = _cache[row, col + 1] + sum;
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                if (_cache == null)
                {
                    return 0;
                }
                return _cache[row2 + 1, col2 + 1] - _cache[row1, col2 + 1] - _cache[row2 + 1, col1] + _cache[row1, col1];
            }
        }
    }
}
