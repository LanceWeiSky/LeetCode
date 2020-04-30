using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace LeetCode._0300._80
{
    class A391 : IQuestion
    {
        public void Run()
        {
            string str = "";
            int[][] rects = JsonSerializer.Deserialize<int[][]>(str);
            var ans = new Solution().IsRectangleCover(rects);
        }

        public class Solution
        {
            public bool IsRectangleCover(int[][] rectangles)
            {
                HashSet<ulong> set = new HashSet<ulong>();
                int size = 0;
                int minX = int.MaxValue;
                int maxX = int.MinValue;
                int minY = int.MaxValue;
                int maxY = int.MinValue;
                foreach (var rect in rectangles)
                {
                    minX = Math.Min(rect[0], minX);
                    maxX = Math.Max(rect[2], maxX);
                    minY = Math.Min(rect[1], minY);
                    maxY = Math.Max(rect[3], maxY);

                    var p1 = GetHash(rect[0], rect[1]);
                    if (!set.Add(p1))
                    {
                        set.Remove(p1);
                    }
                    var p2 = GetHash(rect[2], rect[3]);
                    if (!set.Add(p2))
                    {
                        set.Remove(p2);
                    }
                    var p3 = GetHash(rect[0], rect[3]);
                    if (!set.Add(p3))
                    {
                        set.Remove(p3);
                    }
                    var p4 = GetHash(rect[2], rect[1]);
                    if (!set.Add(p4))
                    {
                        set.Remove(p4);
                    }
                    size += (rect[2] - rect[0]) * (rect[3] - rect[1]);
                }
                return set.Count == 4 
                    && set.Contains(GetHash(minX, minY)) && set.Contains(GetHash(maxX, maxY))
                    && set.Contains(GetHash(minX, maxY)) && set.Contains(GetHash(maxX, minY))
                    && size == (maxX - minX) * (maxY - minY);
            }

            private ulong GetHash(int x, int y)
            {
                var xx = (uint)x;
                var yy = (uint)y;
                return ((ulong)xx << 32) | (ulong)yy;
            }
        }
    }
}
