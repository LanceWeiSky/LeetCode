using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A253 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MinMeetingRooms(int[][] intervals)
            {
                int[] start = new int[intervals.Length];
                int[] end = new int[intervals.Length];
                for (int i = 0; i < intervals.Length; i++)
                {
                    start[i] = intervals[i][0];
                    end[i] = intervals[i][1];
                }
                Array.Sort(start);
                Array.Sort(end);
                int si = 0;
                int ei = 0;
                int count = 0;
                int max = 0;
                while (si < intervals.Length)
                {
                    if (start[si] < end[ei])
                    {
                        count++;
                        si++;
                        max = Math.Max(max, count);
                    }
                    else
                    {
                        count--;
                        ei++;
                    }
                }
                return max;
            }
        }
    }
}
