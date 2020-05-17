using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LeetCode._0900._00
{
    class A909 : IQuestion
    {
        public void Run()
        {
            int[][] board = JsonSerializer.Deserialize<int[][]>("[[-1,1,2,-1],[2,13,15,-1],[-1,10,-1,-1],[-1,6,2,8]]");
            new Solution().SnakesAndLadders(board);
        }

        public class Solution
        {
            public int SnakesAndLadders(int[][] board)
            {
                int n = board.Length;
                if (n < 3)
                {
                    return 1;
                }
                int end = n * n;
                HashSet<int> seen = new HashSet<int>();
                seen.Add(1);
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { n - 1, 0, 1 });
                int count = 0;
                while (queue.Count > 0)
                {
                    count++;
                    var c = queue.Count;
                    for (int i = 0; i < c; i++)
                    {
                        var cur = queue.Dequeue();
                        for (int x = 1; x <= 6; x++)
                        {
                            var next = x + cur[2];
                            var p = GetPoint(next, n);
                            if (board[p[0]][p[1]] != -1)
                            {
                                next = board[p[0]][p[1]];
                                p = GetPoint(next, n);
                            }
                            if (next >= end)
                            {
                                return count;
                            }
                            if (seen.Add(next))
                            {
                                queue.Enqueue(p);
                            }
                        }
                    }
                }
                return -1;
            }

            private int[] GetPoint(int i, int n)
            {
                i--;
                var row = i / n;
                var col = i % n;
                if ((row & 1) == 1)
                {
                    col = n - 1 - col;
                }
                row = n - 1 - row;
                return new int[] { row, col, i + 1 };
            }
        }
    }
}
