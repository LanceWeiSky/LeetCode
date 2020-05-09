using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCode._0200._40
{
    class A252 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CanAttendMeetings(int[][] intervals)
            {
                if (intervals.Length == 0)
                {
                    return true;
                }
                Array.Sort(intervals, new MeetingComparer());
                int end = intervals[0][1];
                for (int i = 1; i < intervals.Length; i++)
                {
                    if (intervals[i][0] < end)
                    {
                        return false;
                    }
                    end = intervals[i][1];
                }
                return true;
            }
        }

        public class MeetingComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[0].CompareTo(y[0]);
            }
        }
    }
}
