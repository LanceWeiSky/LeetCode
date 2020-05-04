using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A560 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int SubarraySum(int[] nums, int k)
            {
                Dictionary<int, int> sums = new Dictionary<int, int>(nums.Length);
                int sum = 0;
                int count = 0;
                foreach (var n in nums)
                {
                    sum += n;
                    if (sum == k)
                    {
                        count++;
                    }
                    if (sums.TryGetValue(sum - k, out var c))
                    {
                        count += c;
                    }
                    if (sums.TryGetValue(sum, out var c2))
                    {
                        sums[sum] = c2 + 1;
                    }
                    else
                    {
                        sums.Add(sum, 1);
                    }
                }
                return count;
            }
        }
    }
}
