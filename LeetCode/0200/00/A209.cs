using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A209 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            int length = int.MaxValue;
            int left = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= s)
                {
                    length = Math.Min(length, i - left + 1);
                    sum -= nums[left];
                    left++;
                }
            }
            if (length > nums.Length)
            {
                length = 0;
            }
            return length;
        }
    }
}
