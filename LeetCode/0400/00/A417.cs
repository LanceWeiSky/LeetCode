using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A417 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<IList<int>> PacificAtlantic(int[][] matrix)
            {
                List<IList<int>> ans = new List<IList<int>>();
                int rows = matrix.Length;
                if (rows == 0)
                {
                    return ans;
                }
                int cols = matrix[0].Length;
                if (cols == 0)
                {
                    return ans;
                }
                int[,] status = new int[rows, cols];
                Queue<int[]> queue = new Queue<int[]>();
                for (int i = 0; i < rows; i++)
                {
                    status[i, 0] |= 1;
                    queue.Enqueue(new int[] { i, 0 });
                    status[i, cols - 1] |= 2;
                    queue.Enqueue(new int[] { i, cols - 1 });
                }
                for (int i = 0; i < cols; i++)
                {
                    status[0, i] |= 1;
                    queue.Enqueue(new int[] { 0, i });
                    status[rows - 1, i] |= 2;
                    queue.Enqueue(new int[] { rows - 1, i });
                }
                int[] dr = new int[] { 1, 0, -1, 0 };
                int[] dc = new int[] { 0, 1, 0, -1 };
                while (queue.Count > 0)
                {
                    var temp = queue.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        int r = temp[0] + dr[i];
                        int c = temp[1] + dc[i];
                        if (r >= 0 && r < rows && c >= 0 && c < cols && matrix[r][c] >= matrix[temp[0]][temp[1]] && status[temp[0], temp[1]] != status[r, c])
                        {
                            status[r, c] |= status[temp[0], temp[1]];
                            queue.Enqueue(new int[] { r, c });
                        }
                    }
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (status[row, col] == 3)
                        {
                            ans.Add(new List<int> { row, col });
                        }
                    }
                }
                return ans;
            }
        }
    }
}
