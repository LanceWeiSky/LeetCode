using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A37 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //编写一个程序，通过已填充的空格来解决数独问题。

        //一个数独的解法需遵循如下规则：


        //	数字 1-9 在每一行只能出现一次。
        //	数字 1-9 在每一列只能出现一次。
        //	数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。


        //空白格用 '.' 表示。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/sudoku-solver
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Solution
        {
            private int _size;
            private int _boardSize;
            private bool[][] _rowUsed;
            private bool[][] _colUsed;
            private bool[][] _boardUsed;

            public void SolveSudoku(char[][] board)
            {
                _size = board.Length;
                _boardSize = (int)Math.Sqrt(_size);
                //记录已经使用过的数字
                _rowUsed = new bool[_size][];
                _colUsed = new bool[_size][];
                _boardUsed = new bool[_size][];
                for (int i = 0; i < _size; i++)
                {
                    _rowUsed[i] = new bool[_size + 1];
                    _colUsed[i] = new bool[_size + 1];
                    _boardUsed[i] = new bool[_size + 1];
                }

                //init
                for (int row = 0; row < _size; row++)
                {
                    for (int col = 0; col < _size; col++)
                    {
                        if (board[row][col] != '.')
                        {
                            SetUsed(board[row][col] - '0', col, row);
                        }
                    }
                }
                Solve(board, 0, 0);
            }

            private void SetUsed(int num, int col, int row)
            {
                _rowUsed[row][num] = true;
                _colUsed[col][num] = true;
                _boardUsed[row / _boardSize * _boardSize + col / _boardSize][num] = true;
            }

            private void RemoveUsed(int num, int col, int row)
            {
                _rowUsed[row][num] = false;
                _colUsed[col][num] = false;
                _boardUsed[row / _boardSize * _boardSize + col / _boardSize][num] = false;
            }

            private bool CanUse(int num, int col, int row)
            {
                return !_rowUsed[row][num] && !_colUsed[col][num] && !_boardUsed[row / _boardSize * _boardSize + col / _boardSize][num];
            }

            private bool Solve(char[][] board, int col, int row)
            {
                if (board[row][col] == '.')
                {
                    for (int i = 1; i <= _size; i++)
                    {
                        if (CanUse(i, col, row))
                        {
                            board[row][col] = (char)(i + '0');
                            SetUsed(i, col, row);
                            if (SolveNext(board, col, row))
                            {
                                return true;
                            }
                            RemoveUsed(i, col, row);
                            board[row][col] = '.';
                        }
                    }
                    return false;
                }
                else
                {
                    return SolveNext(board, col, row);
                }
            }

            private bool SolveNext(char[][] board, int col, int row)
            {
                if (col == _size - 1 && row == _size - 1)
                {
                    return true;
                }
                if (col == _size - 1)
                {
                    return Solve(board, 0, row + 1);
                }
                return Solve(board, col + 1, row);
            }

        }
    }
}
