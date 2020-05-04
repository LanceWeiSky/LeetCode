using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A348 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class TicTacToe
        {
            private int[,] _rows;
            private int[,] _cols;
            private int[] _djxLeft = new int[2];
            private int[] _djxRight = new int[2];
            private int _n;

            /** Initialize your data structure here. */
            public TicTacToe(int n)
            {
                _rows = new int[n, 2];
                _cols = new int[n, 2];
                _n = n;
            }

            /** Player {player} makes a move at ({row}, {col}).
                @param row The row of the board.
                @param col The column of the board.
                @param player The player, can be either 1 or 2.
                @return The current winning condition, can be either:
                        0: No one wins.
                        1: Player 1 wins.
                        2: Player 2 wins. */
            public int Move(int row, int col, int player)
            {
                if (row - col == 0)
                {
                    _djxRight[player - 1]++;
                    if (_djxRight[player - 1] == _n)
                    {
                        return player;
                    }
                }
                if (row + col == _n - 1)
                {
                    _djxLeft[player - 1]++;
                    if (_djxLeft[player - 1] == _n)
                    {
                        return player;
                    }
                }
                _rows[row, player - 1]++;
                if (_rows[row, player - 1] == _n)
                {
                    return player;
                }
                _cols[col, player - 1]++;
                if (_cols[col, player - 1] == _n)
                {
                    return player;
                }
                return 0;
            }
        }
    }
}
