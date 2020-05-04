using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A448 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> FindDisappearedNumbers(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] *= -1;
                    }
                }
                List<int> ans = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        ans.Add(i + 1);
                    }
                }
                return ans;
            }
        }
    }
}
