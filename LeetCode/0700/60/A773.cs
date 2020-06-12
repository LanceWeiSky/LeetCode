using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._60
{
    class A773 : IQuestion
    {
        public void Run()
        {
            new Solution().SlidingPuzzle(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 0, 5 } });
        }

        public class Solution
        {
            public int SlidingPuzzle(int[][] board)
            {
                int[][] moveTable = new int[][]{
                    new int[]{1,3},
                    new int[]{0, 2, 4},
                    new int[]{1, 5},
                    new int[]{0, 4},
                    new int[]{1, 3, 5},
                    new int[]{2, 4},
                };
                (int state, int index) = GetState(board);
                (int final, int fIndex) = GetState(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 0 } });
                HashSet<int> seen = new HashSet<int>();
                seen.Add(state);
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { state, index });
                int steps = 0;
                while (queue.Count > 0)
                {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        if (temp[0] == final)
                        {
                            return steps;
                        }
                        foreach (var next in moveTable[temp[1]])
                        {
                            var nextState = MoveTo(temp[0], temp[1], next);
                            if (seen.Add(nextState))
                            {
                                queue.Enqueue(new int[] { nextState, next });
                            }
                        }
                    }
                    steps++;
                }
                return -1;
            }

            private int MoveTo(int state, int from, int to)
            {
                from = 5 - from;
                to = 5 - to;
                var mask1 = 7 << (from * 3);
                var mask2 = 7 << (to * 3);
                var fValue = (state & mask1) >> (from * 3);
                var tValue = (state & mask2) >> (to * 3);
                state = state & ~mask1 & ~mask2;
                state |= fValue << (to * 3);
                state |= tValue << (from * 3);
                return state;
            }

            private (int, int) GetState(int[][] board)
            {
                int state = 0;
                int index = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var temp = i * 3 + j;
                        if (board[i][j] == 0)
                        {
                            index = temp;
                        }
                        state |= board[i][j] << ((5 - temp) * 3);
                    }
                }
                return (state, index);
            }
        }
    }
}
