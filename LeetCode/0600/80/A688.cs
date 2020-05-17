using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._80
{
    class A688 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public double KnightProbability(int N, int K, int r, int c)
            {
                double[,] dp = new double[N, N];
                dp[r, c] = 1d;
                int[] dr = new int[] { 2, 2, 1, 1, -1, -1, -2, -2 };
                int[] dc = new int[] { 1, -1, 2, -2, 2, -2, 1, -1 };
                for (int i = 0; i < K; i++)
                {
                    double[,] dp2 = new double[N, N];
                    for (int row = 0; row < N; row++)
                    {
                        for (int col = 0; col < N; col++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                var tr = row + dr[j];
                                var tc = col + dc[j];
                                if (tr >= 0 && tr < N && tc >= 0 && tc < N)
                                {
                                    dp2[row, col] += dp[tr, tc] / 8d;
                                }
                            }
                        }
                    }
                    dp = dp2;
                }
                double ans = 0;
                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < N; col++)
                    {
                        ans += dp[row, col];
                    }
                }
                return ans;
            }
        }
    }
}
