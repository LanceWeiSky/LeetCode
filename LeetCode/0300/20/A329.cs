using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A329 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LongestIncreasingPath(int[][] matrix)
            {
                int rows = matrix.Length;
                if (rows == 0)
                {
                    return 0;
                }
                int cols = matrix[0].Length;
                if (cols == 0)
                {
                    return 0;
                }
                int[] dr = new int[] { 1, 0, -1, 0 };
                int[] dc = new int[] { 0, 1, 0, -1 };
                int[,] degree = new int[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            var tr = row + dr[i];
                            var tc = col + dc[i];
                            if (tr >= 0 && tr < rows && tc >= 0 && tc < cols && matrix[row][col] > matrix[tr][tc])
                            {
                                degree[row, col]++;
                            }
                        }
                    }
                }

                Queue<int[]> queue = new Queue<int[]>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (degree[row, col] == 0)
                        {
                            queue.Enqueue(new int[] { row, col });
                        }
                    }
                }

                int level = 0;
                while (queue.Count > 0)
                {
                    level++;
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        for (int j = 0; j < 4; j++)
                        {
                            var row = temp[0] + dr[j];
                            var col = temp[1] + dc[j];
                            if (row >= 0 && row < rows && col >= 0 && col < cols && matrix[row][col] > matrix[temp[0]][temp[1]])
                            {
                                degree[row, col]--;
                                if (degree[row, col] == 0)
                                {
                                    queue.Enqueue(new int[] { row, col });
                                }
                            }
                        }
                    }
                }
                return level;
            }
        }
    }
}
