using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A59 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个正整数 n，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。

        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }
            int[] dr = new int[] { 0, 1, 0, -1 };
            int[] dc = new int[] { 1, 0, -1, 0 };

            int length = n * n;
            int row = 0;
            int col = 0;
            int di = 0;
            for (int i = 1; i <= length; i++)
            {
                matrix[row][col] = i;
                var tr = row + dr[di];
                var tc = col + dc[di];
                if (tr < 0 || tr >= n || tc < 0 || tc >= n || matrix[tr][tc] > 0)
                {
                    di = (di + 1) % 4;
                    tr = row + dr[di];
                    tc = col + dc[di];
                }
                row = tr;
                col = tc;
            }
            return matrix;
        }
    }
}
