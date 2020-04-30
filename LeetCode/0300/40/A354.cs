using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0300._40
{
    class A354 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().MaxEnvelopes(new int[][] { new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 } });
        }

        public class Solution
        {
            public int MaxEnvelopes(int[][] envelopes)
            {
                if (envelopes.Length == 0 || envelopes[0].Length == 0)
                {
                    return 0;
                }
                Array.Sort(envelopes, new Comparer());
                var nums = envelopes.Select(e => e[1]).ToArray();
                return LIS(nums);
            }

            private int LIS(int[] nums)
            {
                int len = 0;
                int i = 0;
                int[] dp = new int[nums.Length];
                foreach (var n in nums)
                {
                    i = Array.BinarySearch(dp, 0, len, n);
                    if (i < 0)
                    {
                        i = ~i;
                    }
                    dp[i] = n;
                    if (i == len)
                    {
                        len++;
                    }
                }
                return len;
            }
        }

        public class Comparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                var c = x[0].CompareTo(y[0]);
                if (c == 0)
                {
                    c = y[1].CompareTo(x[1]);
                }
                return c;
            }
        }
    }
}
