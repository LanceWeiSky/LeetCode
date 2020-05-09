using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LeetCode._0900._80
{
    class A983 : IQuestion
    {
        public void Run()
        {
            int[] days = JsonSerializer.Deserialize<int[]>("[1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21,24,25,27,28,29,30,31,34,37,38,39,41,43,44,45,47,48,49,54,57,60,62,63,66,69,70,72,74,76,78,80,81,82,83,84,85,88,89,91,93,94,97,99]");
            var ans = new Solution().MincostTickets(days, new int[] { 9, 38, 134 });
        }

        public class Solution
        {
            public int MincostTickets(int[] days, int[] costs)
            {
                if (days.Length == 0 || costs.Length == 0)
                {
                    return 0;
                }
                int[] durations = new int[] { 1, 7, 30 };
                int[] cache = new int[days.Length];
                return DP(days, costs, cache, durations, 0);
            }

            private int DP(int[] days, int[] costs, int[] cache, int[] durations, int i)
            {
                if (i >= days.Length)
                {
                    return 0;
                }
                if (cache[i] != 0)
                {
                    return cache[i];
                }
                cache[i] = int.MaxValue;
                int k = i + 1;
                for (int j = 0; j < 3; j++)
                {
                    while (k < days.Length && days[k] < days[i] + durations[j])
                    {
                        k++;
                    }
                    cache[i] = Math.Min(cache[i], costs[j] + DP(days, costs, cache, durations, k));
                }
                return cache[i];
            }
        }
    }
}
