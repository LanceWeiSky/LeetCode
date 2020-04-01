using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A54 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。

        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
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
            bool[,] used = new bool[rows, cols];
            int[] dr = new int[] { 0, 1, 0, -1 };
            int[] dc = new int[] { 1, 0, -1, 0 };
            int di = 0;
            int row = 0;
            int col = 0;
            while (row >= 0 && row < rows && col >= 0 && col < cols && !used[row, col])
            {
                ans.Add(matrix[row][col]);
                used[row, col] = true;
                var nr = row + dr[di];
                var nc = col + dc[di];
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || used[nr, nc])
                {
                    di = (di + 1) % 4;
                    row += dr[di];
                    col += dc[di];
                }
                else
                {
                    row = nr;
                    col = nc;
                }
            }
            return ans;
        }
    }
}
