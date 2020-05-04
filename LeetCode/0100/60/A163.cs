using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A163 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
            {
                List<string> ans = new List<string>();
                long left = (long)lower - 1;
                long right = (long)upper + 1;
                foreach (var n in nums)
                {
                    if (left == n)
                    {
                        continue;
                    }
                    if (n != left + 1)
                    {
                        if (n == left + 2)
                        {
                            ans.Add((left + 1).ToString());
                        }
                        else
                        {
                            ans.Add($"{left + 1}->{n - 1}");
                        }
                    }
                    left = n;
                }
                if (left + 1 != right)
                {
                    if (left + 2 == right)
                    {
                        ans.Add((left + 1).ToString());
                    }
                    else
                    {
                        ans.Add($"{left + 1}->{right - 1}");
                    }
                }
                return ans;
            }
        }
    }
}
