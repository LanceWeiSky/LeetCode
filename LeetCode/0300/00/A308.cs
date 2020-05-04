using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LeetCode._0300._00
{
    class A308 : IQuestion
    {
        public void Run()
        {
            var str = "[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]";
            var m = JsonSerializer.Deserialize<int[][]>(str);
            var instance = new NumMatrix(m);
            var s = instance.SumRegion(2, 1, 4, 3);
        }

        public class NumMatrix
        {

            private readonly int[,] _c;
            private readonly int[][] _matrix;
            private readonly int _rows;
            private readonly int _cols;

            public NumMatrix(int[][] matrix)
            {
                _matrix = matrix;
                int rows = matrix.Length;
                _rows = rows;
                if (rows == 0)
                {
                    return;
                }
                int cols = matrix[0].Length;
                _cols = cols;
                if (cols == 0)
                {
                    return;
                }
                _c = new int[rows + 1, cols + 1];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        UpdateInternal(row + 1, col + 1, matrix[row][col]);
                    }
                }
            }

            private void UpdateInternal(int row, int col, int val)
            {
                while (row <= _rows)
                {
                    var y = col;
                    while (y <= _cols)
                    {
                        _c[row, y] += val;
                        y += y & -y;
                    }
                    row += row & -row;
                }
            }

            public void Update(int row, int col, int val)
            {
                if (_c == null)
                {
                    return;
                }
                UpdateInternal(row + 1, col + 1, val - _matrix[row][col]);
                _matrix[row][col] = val;
            }

            private int Sum(int row, int col)
            {
                int s = 0;
                while (row > 0)
                {
                    var y = col;
                    while (y > 0)
                    {
                        s += _c[row, y];
                        y -= y & -y;
                    }
                    row -= row & -row;
                }
                return s;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                if (_c == null)
                {
                    return 0;
                }
                return Sum(row2 + 1, col2 + 1) - Sum(row1, col2 + 1) - Sum(row2 + 1, col1) + Sum(row1, col1);
            }
        }
    }
}
