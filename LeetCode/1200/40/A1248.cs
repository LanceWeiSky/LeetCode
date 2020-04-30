using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._40
{
    class A1248 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NumberOfSubarrays(int[] nums, int k)
            {
                int ans = 0;
                int[] cnt = new int[nums.Length + 1];
                cnt[0] = 1;
                int oddCount = 0;
                foreach (var n in nums)
                {
                    if ((n & 1) == 1)
                    {
                        oddCount++;
                    }
                    cnt[oddCount]++;
                    if (oddCount >= k)
                    {
                        ans += cnt[oddCount - k];
                    }
                }
                return ans;
            }
        }
    }
}
