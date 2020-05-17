using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A442 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> FindDuplicates(int[] nums)
            {
                List<int> ans = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var n = Math.Abs(nums[i]);
                    if (nums[n - 1] < 0)
                    {
                        ans.Add(n);
                    }
                    else
                    {
                        nums[n - 1] = -nums[n - 1];
                    }
                }
                return ans;
            }
        }
    }
}
