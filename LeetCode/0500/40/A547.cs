using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A547 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FindCircleNum(int[][] M)
            {
                bool[] visited = new bool[M.Length];
                int count = 0;
                for (int i = 0; i < M.Length; i++)
                {
                    if (!visited[i])
                    {
                        Dfs(M, i, visited);
                        count++;
                    }
                }
                return count;
            }

            private void Dfs(int[][] M, int i, bool[] visited)
            {
                visited[i] = true;
                for (int j = 0; j < M.Length; j++)
                {
                    if (M[i][j] == 1 && !visited[j])
                    {
                        visited[j] = true;
                        Dfs(M, j, visited);
                    }
                }
            }
        }
    }
}
