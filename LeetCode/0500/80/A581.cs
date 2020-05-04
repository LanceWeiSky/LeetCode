using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._80
{
    class A581 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FindUnsortedSubarray(int[] nums)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[i - 1])
                    {
                        min = Math.Min(min, nums[i]);
                        max = Math.Max(max, nums[i - 1]);
                    }
                }

                int left = 0, right = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > min)
                    {
                        left = i;
                        break;
                    }
                }
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (nums[i] < max)
                    {
                        right = i;
                        break;
                    }
                }
                if (right <= left)
                {
                    return 0;
                }
                return right - left + 1;
            }
        }
    }
}
