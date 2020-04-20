using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A200 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0)
            {
                return 0;
            }
            int cols = grid[0].Length;
            if (cols == 0)
            {
                return 0;
            }
            int n = rows * cols;
            UnionSet uset = new UnionSet(n);
            for (int row = 0; row < rows; row++)
            {
                int index = row * cols;
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        if (row > 0 && grid[row - 1][col] == '1')
                        {
                            uset.Union(index + col, index - cols + col);
                        }
                        if (col > 0 && grid[row][col - 1] == '1')
                        {
                            uset.Union(index + col, index + col - 1);
                        }
                    }
                }
            }

            HashSet<int> count = new HashSet<int>();
            for (int row = 0; row < rows; row++)
            {
                int index = row * cols;
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        count.Add(uset.Find(index + col));
                    }
                }
            }
            return count.Count;
        }
    }
}
