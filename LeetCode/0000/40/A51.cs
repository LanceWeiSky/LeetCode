using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A51 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。

        //给定一个整数 n，返回所有不同的 n 皇后问题的解决方案。

        //每一种解法包含一个明确的 n 皇后问题的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/n-queens
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> ans = new List<IList<string>>(n);
            int[] rows = new int[n];
            SolveQueens(ans, rows, 0, 0, 0, 0, n);
            return ans;
        }

        private void SolveQueens(IList<IList<string>> ans, int[] rows, int row, int col, int ld, int rd, int n)
        { 
            if(row == n)
            {
                List<string> values = new List<string>();
                foreach (var v in rows)
                {
                    values.Add(GetValues(v, n));
                }
                ans.Add(values);
                return;
            }

            int bit = ~(col | ld | rd) & ((1 << n) - 1);
            while(bit != 0)
            {
                var pick = bit & -bit;
                rows[row] = pick;
                SolveQueens(ans, rows, row + 1, col | pick, (ld | pick) << 1, (rd | pick) >> 1, n);
                bit = bit & (bit - 1);
            }
        }

        private string GetValues(int v, int n)
        {
            char[] cs = new char[n];
            for (int i = n - 1; i >= 0; i--)
            {
                if ((v & 1) == 1)
                {
                    cs[i] = 'Q';
                }
                else
                {
                    cs[i] = '.';
                }
                v = v >> 1;
            }
            return new string(cs);
        }

        public class Solution
        {
            private bool[] _colCache;
            private bool[] _d1Cache;
            private bool[] _d2Cache;

            public IList<IList<string>> SolveNQueens(int n)
            {
                _colCache = new bool[n];
                _d1Cache = new bool[2 * n];
                _d2Cache = new bool[2 * n];
                IList<IList<string>> ans = new List<IList<string>>(n);
                char[,] board = new char[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        board[i, j] = '.';
                    }
                }

                SolveNQueens(ans, board, 0, n);
                return ans;
            }

            private void SolveNQueens(IList<IList<string>> ans, char[,] board, int row, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!CanSetQ(row, i, n))
                    {
                        continue;
                    }
                    SetQ(board, row, i, n);
                    if (row + 1 == n)
                    {
                        List<string> temp = new List<string>(n);
                        for (int k = 0; k < n; k++)
                        {
                            StringBuilder builder = new StringBuilder(n);
                            for (int k2 = 0; k2 < n; k2++)
                            {
                                builder.Append(board[k, k2]);
                            }
                            temp.Add(builder.ToString());
                        }
                        ans.Add(temp);
                    }
                    else
                    {
                        SolveNQueens(ans, board, row + 1, n);
                    }
                    ResetQ(board, row, i, n);
                }
            }

            private bool CanSetQ(int row, int col, int n)
            {
                return !_colCache[col] && !_d1Cache[row + col] && !_d2Cache[row - col + n];
            }

            private void SetQ(char[,] board, int row, int col, int n)
            {
                board[row, col] = 'Q';
                _colCache[col] = true;
                _d1Cache[row + col] = true;
                _d2Cache[row - col + n] = true;
            }

            private void ResetQ(char[,] board, int row, int col, int n)
            {
                board[row, col] = '.';
                _colCache[col] = false;
                _d1Cache[row + col] = false;
                _d2Cache[row - col + n] = false;
            }
        }
    }
}
