using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A228 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            if(nums.Length == 0)
            {
                return new List<string>();
            }
            List<string> ans = new List<string>();
            int start = nums[0];
            int prev = start;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != prev + 1)
                {
                    if (prev == start)
                    {
                        ans.Add(start.ToString());
                    }
                    else
                    {
                        ans.Add($"{start}->{prev}");
                    }
                    start = nums[i];
                    prev = start;
                }
                else
                {
                    prev++;
                }
            }
            if (prev == start)
            {
                ans.Add(start.ToString());
            }
            else
            {
                ans.Add($"{start}->{prev}");
            }
            return ans;
        }
    }
}
