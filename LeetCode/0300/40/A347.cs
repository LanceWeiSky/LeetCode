using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A347 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                Dictionary<int, int> counts = new Dictionary<int, int>();
                foreach (var n in nums)
                {
                    counts.TryGetValue(n, out var c);
                    counts[n] = c + 1;
                }
                List<int>[] buckets = new List<int>[nums.Length];
                foreach (var c in counts)
                {
                    if (buckets[c.Value] == null)
                    {
                        buckets[c.Value] = new List<int> { c.Key };
                    }
                    else
                    {
                        buckets[c.Value].Add(c.Key);
                    }
                }
                int[] ans = new int[k];
                for (int i = buckets.Length - 1; i >= 0; i--)
                {
                    if (buckets[i] != null)
                    {
                        foreach (var v in buckets[i])
                        {
                            ans[--k] = v;
                            if (k == 0)
                            {
                                return ans;
                            }
                        }
                    }
                }
                return ans;
            }
        }
    }
}
