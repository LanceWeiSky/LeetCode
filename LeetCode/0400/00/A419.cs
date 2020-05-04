using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A419 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CountBattleships(char[][] board)
            {
                int rows = board.Length;
                if (rows == 0)
                {
                    return 0;
                }
                int cols = board[0].Length;
                if (cols == 0)
                {
                    return 0;
                }
                int count = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (board[row][col] == 'X' && (col == 0 || board[row][col - 1] == '.') && (row == 0 || board[row - 1][col] == '.'))
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }
    }
}
