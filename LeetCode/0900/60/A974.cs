using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._60
{
    class A974 : IQuestion
    {
        public void Run()
        {
            new Solution().SubarraysDivByK(new int[] { 4, 5, 0, -2, -3, 1 }, 5);
        }

        public class Solution
        {
            public int SubarraysDivByK(int[] A, int K)
            {
                Dictionary<int, int> counter = new Dictionary<int, int>();
                counter.Add(0, 1);
                int ans = 0;
                int sum = 0;
                foreach (var n in A)
                {
                    sum = (sum + n) % K;
                    if(sum < 0)
                    {
                        sum += K;
                    }
                    if (counter.TryGetValue(sum, out var count))
                    {
                        ans += count;
                    }
                    count++;
                    counter[sum] = count;
                }
                return ans;
            }
        }
    }
}
