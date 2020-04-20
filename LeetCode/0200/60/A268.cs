using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A268 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MissingNumber(int[] nums)
            {
                int ans = nums.Length;
                for (int i = 0; i < nums.Length; i++)
                {
                    ans = ans ^ i ^ nums[i];
                }
                return ans;
            }
        }
    }
}
