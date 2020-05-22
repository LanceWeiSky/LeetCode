using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A286 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public void WallsAndGates(int[][] rooms)
            {
                int rows = rooms.Length;
                if(rows == 0)
                {
                    return;
                }
                int cols = rooms[0].Length;
                if(cols == 0)
                {
                    return;
                }
                Queue<int[]> queue = new Queue<int[]>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (rooms[row][col] == 0)
                        {
                            queue.Enqueue(new int[] { row, col });
                        }
                    }
                }
                int[] dr = new int[] { 0, 1, 0, -1 };
                int[] dc = new int[] { 1, 0, -1, 0 };
                int steps = 0;
                while (queue.Count > 0)
                {
                    steps++;
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        for (int k = 0; k < 4; k++)
                        {
                            var row = temp[0] + dr[k];
                            var col = temp[1] + dc[k];
                            if (row >= 0 && row < rows && col >= 0 && col < cols && rooms[row][col] == int.MaxValue)
                            {
                                rooms[row][col] = steps;
                                queue.Enqueue(new int[] { row, col });
                            }
                        }
                    }
                }
            }
        }
    }
}
