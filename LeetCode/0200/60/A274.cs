using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A274 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int HIndex(int[] citations)
            {
                int n = citations.Length;
                int[] buckets = new int[n + 1];
                foreach (var c in citations)
                {
                    buckets[Math.Min(n, c)]++;
                }
                int s = buckets[n];
                for (; n > s; s += buckets[n])
                {
                    n--;
                }
                return n;
            }
        }
    }
}
