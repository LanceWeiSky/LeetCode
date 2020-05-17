using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._80
{
    class A490 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool HasPath(int[][] maze, int[] start, int[] destination)
            {
                int rows = maze.Length;
                if(rows == 0)
                {
                    return false;
                }
                int cols = maze[0].Length;
                if(cols == 0)
                {
                    return false;
                }
                int[] dr = new int[] { 0, 1, 0, -1 };
                int[] dc = new int[] { 1, 0, -1, 0 };
                bool[,] visited = new bool[rows, cols];
                visited[start[0], start[1]] = true;
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    if (temp[0] == destination[0] && temp[1] == destination[1])
                    {
                        return true;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int row = temp[0] + dr[i];
                        int col = temp[1] + dc[i];
                        while (row >= 0 && row < rows && col >= 0 && col < cols && maze[row][col] == 0)
                        {
                            row += dr[i];
                            col += dc[i];
                        }
                        row -= dr[i];
                        col -= dc[i];
                        if (visited[row, col])
                        {
                            continue;
                        }
                        visited[row, col] = true;
                        queue.Enqueue(new int[] { row, col });
                    }
                }
                return false;
            }
        }
    }
}
