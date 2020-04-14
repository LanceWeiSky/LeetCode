using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A169 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int MajorityElement(int[] nums)
        {
            int ans = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == ans)
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    ans = nums[i];
                    count = 1;
                }
            }
            return ans;
        }
    }
}
