using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LeetCode._0200._00
{
    class A218 : IQuestion
    {
        public void Run()
        {
            var str = "";
            var nums = JsonSerializer.Deserialize<int[][]>(str);
            var ans = GetSkyline(nums);
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            List<int[]> buildings2 = new List<int[]>(buildings.Length * 2);
            foreach (var b in buildings)
            {
                buildings2.Add(new int[] { b[0], -b[2] });
                buildings2.Add(new int[] { b[1], b[2] });
            }
            buildings2.Sort((x, y) =>
            {
                var c = x[0].CompareTo(y[0]);
                if (c == 0)
                {
                    c = x[1].CompareTo(y[1]);
                }
                return c;
            });

            List<IList<int>> ans = new List<IList<int>>();
            DuplicatedSortedTree<int> heap = new DuplicatedSortedTree<int>();
            int prev = 0;
            foreach (var b in buildings2)
            {
                if (b[1] < 0)
                {
                    heap.Add(-b[1]);
                }
                else
                {
                    heap.Remove(b[1]);
                }
                int max = 0;
                if (heap.Count > 0)
                {
                    max = heap.Max;
                }
                if (max != prev)
                {
                    ans.Add(new List<int> { b[0], max });
                }
                prev = max;
            }
            return ans;
        }

    }
}
