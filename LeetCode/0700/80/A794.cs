using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._80
{
    class A794 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool ValidTicTacToe(string[] board)
            {
                int xc = 0, oc = 0;
                foreach (var str in board)
                {
                    foreach (var c in str)
                    {
                        if (c == 'X')
                        {
                            xc++;
                        }
                        else if (c == 'O')
                        {
                            oc++;
                        }
                    }
                }
                if (xc != oc && xc != oc + 1)
                {
                    return false;
                }
                var xWin = Win(board, 'X');
                var oWin = Win(board, 'O');
                if (xWin && oWin)
                {
                    return false;
                }
                if (xWin && xc != oc + 1 || oWin && xc != oc)
                {
                    return false;
                }
                return true;
            }

            private bool Win(string[] board, char p)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i][0] == p && board[i][1] == p && board[i][2] == p
                        || board[0][i] == p && board[1][i] == p && board[2][i] == p)
                    {
                        return true;
                    }
                }
                if (board[0][0] == p && board[1][1] == p && board[2][2] == p
                    || board[0][2] == p && board[1][1] == p && board[2][0] == p)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
