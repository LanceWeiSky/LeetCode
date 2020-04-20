using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A542 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int[][] UpdateMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] ans = new int[rows][];
            bool[,] seen = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                ans[i] = new int[cols];
            }
            Queue<int[]> queue = new Queue<int[]>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        seen[row, col] = true;
                        queue.Enqueue(new int[] { row, col });
                    }
                }
            }

            int[] dr = new int[] { 0, 1, 0, -1 };
            int[] dc = new int[] { 1, 0, -1, 0 };
            int distance = 0;

            while (queue.Count > 0)
            {
                distance++;
                var c = queue.Count;
                for (int i = 0; i < c; i++)
                {
                    var rc = queue.Dequeue();
                    for (int k = 0; k < 4; k++)
                    {
                        int row = rc[0] + dr[k];
                        int col = rc[1] + dc[k];
                        if (row >= 0 && row < rows && col >= 0 && col < cols && !seen[row, col])
                        {
                            seen[row, col] = true;
                            ans[row][col] = distance;
                            queue.Enqueue(new int[] { row, col });
                        }
                    }
                }
            }
            return ans;
        }
    }
}
