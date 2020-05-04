using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BinaryIndexedTree2D<T>
    {
        private readonly int _rows;
        private readonly int _cols;
        private readonly T[,] _c;
        private readonly Func<T, T, T> _merger;

        public BinaryIndexedTree2D(int rows, int cols, Func<T, T, T> merger)
        {
            _rows = rows + 1;
            _cols = cols + 1;
            _c = new T[_rows, _cols];
            _merger = merger;
        }

        public void Update(int row, int col, T value)
        {
            row++;
            col++;
            while (row <= _rows)
            {
                var tempCol = col;
                while (tempCol <= _cols)
                {
                    _c[row, tempCol] = _merger(_c[row, tempCol], value);
                    tempCol += tempCol & -tempCol;
                }
                row += row & -row;
            }
        }

        public T GetSum(int row, int col)
        {
            row++;
            col++;
            T s = default;
            while (row > 0)
            {
                var tempCol = col;
                while (col > 0)
                {
                    s = _merger(s, _c[row, tempCol]);
                    tempCol -= tempCol & -tempCol;
                }
                row -= row & -row;
            }
            return s;
        }
    }
}
