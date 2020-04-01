using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A57 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出一个无重叠的 ，按照区间起始端点排序的区间列表。
        //在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> ans = new List<int[]>(intervals.Length + 1);
            int i = 0;
            while (i < intervals.Length && newInterval[0] > intervals[i][0])
            {
                ans.Add(intervals[i]);
                i++;
            }
            if (i == 0 || newInterval[0] > ans[ans.Count - 1][1])
            {
                ans.Add(newInterval);
            }
            else
            {
                ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], newInterval[1]);
            }
            for (; i < intervals.Length; i++)
            {
                if (intervals[i][0] > ans[ans.Count - 1][1])
                {
                    ans.Add(intervals[i]);
                }
                else
                {
                    ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], intervals[i][1]);
                }
            }
            return ans.ToArray();
        }
    }
}
