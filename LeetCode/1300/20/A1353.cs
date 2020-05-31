using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1300._20
{
    class A1353 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxEvents(int[][] events)
            {
                if (events.Length < 2)
                {
                    return events.Length;
                }
                Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();
                int min = int.MaxValue;
                int max = int.MinValue;
                for(int i = 0; i < events.Length; i++)
                {
                    if (!map.TryGetValue(events[i][0], out var list))
                    {
                        list = new List<int[]>();
                        map.Add(events[i][0], list);
                    }
                    list.Add(new int[] { events[i][1], i });
                    min = Math.Min(min, events[i][0]);
                    max = Math.Max(max, events[i][1]);
                }
                int count = 0;
                int currentDay = min;
                SortedSet<int[]> set = new SortedSet<int[]>(new EventComparer());
                while(currentDay <= max)
                {
                    if (map.TryGetValue(currentDay, out var list))
                    {
                        foreach (var item in list)
                        {
                            set.Add(item);
                        }
                    }
                    if (set.Count > 0)
                    {
                        var temp = set.Min;
                        while (temp[0] < currentDay)
                        {
                            set.Remove(temp);
                            if (set.Count > 0)
                            {
                                temp = set.Min;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (set.Count > 0)
                    {
                        count++;
                        set.Remove(set.Min);
                    }
                    currentDay++;
                }
                return count;
            }

            private class EventComparer : IComparer<int[]>
            {
                public int Compare(int[] x, int[] y)
                {
                    var c = x[0].CompareTo(y[0]);
                    if (c == 0)
                    {
                        c = x[1].CompareTo(y[1]);
                    }
                    return c;
                }
            }
        }
    }
}
