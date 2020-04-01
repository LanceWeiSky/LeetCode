using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A56 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出一个区间的集合，请合并所有重叠的区间。

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length < 2)
            {
                return intervals;
            }
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
            List<int[]> ans = new List<int[]> { intervals[0] };
            for (int i = 1; i < intervals.Length; i++)
            {
                if (ans[ans.Count - 1][1] >= intervals[i][0])
                {
                    ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], intervals[i][1]);
                }
                else
                {
                    ans.Add(intervals[i]);
                }
            }
            return ans.ToArray();
        }
    }
}
