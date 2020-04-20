using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A239 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] MaxSlidingWindow(int[] nums, int k)
            {
                int[] ans = new int[nums.Length - k + 1];
                int index = -1;
                int max = int.MinValue;
                for (int i = 0; i < nums.Length - k + 1; i++)
                {
                    if (i > index)
                    {
                        max = int.MinValue;
                        for (int j = 0; j < k; j++)
                        {
                            if (nums[j + i] >= max)
                            {
                                index = j + i;
                                max = nums[j + i];
                            }
                        }
                    }
                    else
                    {
                        if (nums[i + k - 1] >= max)
                        {
                            index = i + k - 1;
                            max = nums[i + k - 1];
                        }
                    }
                    ans[i] = max;
                }
                return ans;
            }
        }
    }
}
