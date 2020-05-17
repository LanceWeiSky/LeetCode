using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._20
{
    class A529 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private readonly int[] _dr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            private readonly int[] _dc = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            public char[][] UpdateBoard(char[][] board, int[] click)
            {
                int rows = board.Length;
                if (rows == 0)
                {
                    return board;
                }
                int cols = board[0].Length;
                if (cols == 0)
                {
                    return board;
                }
                if (board[click[0]][click[1]] == 'M')
                {
                    board[click[0]][click[1]] = 'X';
                }
                else if(board[click[0]][click[1]] == 'E')
                {
                    var count = CountM(board, click, rows, cols);
                    if (count == 0)
                    {
                        BFS(board, click, rows, cols);
                    }
                    else
                    {
                        board[click[0]][click[1]] = (char)(count + '0');
                    }
                }
                return board;
            }

            private int CountM(char[][] board, int[] click, int rows, int cols)
            {
                int count = 0;
                for (int i = 0; i < 8; i++)
                {
                    var row = click[0] + _dr[i];
                    var col = click[1] + _dc[i];
                    if (row >= 0 && row < rows && col >= 0 && col < cols && board[row][col] == 'M')
                    {
                        count++;
                    }
                }
                return count;
            }

            private void BFS(char[][] board, int[] click, int rows, int cols)
            {
                HashSet<long> seen = new HashSet<long>();
                seen.Add(GetHash(click[0], click[1]));
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(click);
                while (queue.Count > 0)
                {
                    var c = queue.Dequeue();
                    board[c[0]][c[1]] = 'B';
                    for (int i = 0; i < 8; i++)
                    {
                        var row = c[0] + _dr[i];
                        var col = c[1] + _dc[i];
                        if (row >= 0 && row < rows && col >= 0 && col < cols && seen.Add(GetHash(row, col)))
                        {
                            var count = CountM(board, new int[] { row, col }, rows, cols);
                            if (count == 0)
                            {
                                queue.Enqueue(new int[] { row, col });
                            }
                            else
                            {
                                board[row][col] = (char)(count + '0');
                            }
                        }
                    }
                }
            }

            private long GetHash(int x, int y)
            {
                long h = x;
                h <<= 32;
                h |= (long)y;
                return h;
            }

        }
    }
}
