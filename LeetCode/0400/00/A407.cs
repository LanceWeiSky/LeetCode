using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace LeetCode._0400._00
{
    class A407 : IQuestion
    {
        public void Run()
        {
            string str = "[[12,13,1,12],[13,4,13,12],[13,8,10,12],[12,13,12,12],[13,13,13,13]]";
            int[][] map = JsonSerializer.Deserialize<int[][]>(str);
            var ans = new Solution().TrapRainWater(map);
        }

        public class Solution
        {
            public int TrapRainWater(int[][] heightMap)
            {
                int rows = heightMap.Length;
                int cols = heightMap[0].Length;
                if (cols < 3 || rows < 3)
                {
                    return 0;
                }
                bool[,] visited = new bool[rows, cols];
                DuplicatedSortedTree<int[]> heap = new DuplicatedSortedTree<int[]>(new RainComparer(), new RainComparer());
                for (int i = 0; i < rows; i++)
                {
                    heap.Add(new int[] { i, 0, heightMap[i][0] });
                    heap.Add(new int[] { i, cols - 1, heightMap[i][cols - 1] });
                    visited[i, 0] = true;
                    visited[i, cols - 1] = true;
                }
                for (int i = 1; i < cols - 1; i++)
                {
                    heap.Add(new int[] { 0, i, heightMap[0][i] });
                    heap.Add(new int[] { rows - 1, i, heightMap[rows - 1][i] });
                    visited[0, i] = true;
                    visited[rows - 1, i] = true;
                }
                int ans = 0;
                int[] d = new int[] { -1, 0, 1, 0, -1 };
                while (heap.Count > 0)
                {
                    var temp = heap.Min;
                    heap.Remove(temp);
                    for (int i = 0; i < 4; i++)
                    {
                        int r = temp[0] + d[i];
                        int c = temp[1] + d[i + 1];
                        if (r >= 0 && r < rows && c >= 0 && c < cols && !visited[r, c])
                        {
                            if (heightMap[r][c] < temp[2])
                            {
                                ans += temp[2] - heightMap[r][c];
                            }
                            visited[r, c] = true;
                            heap.Add(new int[] { r, c, Math.Max(temp[2], heightMap[r][c]) });
                        }
                    }
                }
                return ans;
            }

            public class RainComparer : IComparer<int[]>, IHashGenerator<int[]>
            {
                public int Compare(int[] x, int[] y)
                {
                    return x[2].CompareTo(y[2]);
                }

                public int GetHashCode(int[] obj)
                {
                    return obj[2].GetHashCode();
                }
            }
        }
    }
}
