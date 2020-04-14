using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A149 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二维平面，平面上有 n 个点，求最多有多少个点在同一条直线上。

        public int MaxPoints(int[][] points)
        {
            int n = points.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                int max = 0;
                int duplicate = 0;
                Dictionary<string, int> map = new Dictionary<string, int>();
                for (int j = i + 1; j < n; j++)
                {
                    int dx = points[i][0] - points[j][0];
                    int dy = points[i][1] - points[j][1];
                    if (dx == 0 && dy == 0)
                    {
                        duplicate++;
                        continue;
                    }
                    int g = Gcd(dx, dy);
                    string k = $"{dx/g}/{dy/g}";
                    map.TryGetValue(k, out var count);
                    count++;
                    map[k] = count;
                    max = Math.Max(max, count);
                }
                ans = Math.Max(ans, max + duplicate + 1);
            }
            return ans;
        }

        private int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
    }
}
