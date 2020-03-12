using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF59_1 : IQuestion
    {
        public void Run()
        {
            int[] nums = new int[] {7, 2, 4 };
            var ans = MaxSlidingWindow(nums, 2);
        }

        //给定一个数组 nums 和滑动窗口的大小 k，请找出所有滑动窗口里的最大值。

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if(k == 0)
            {
                return new int[0];
            }
            if(k == 1)
            {
                return nums;
            }
            int[] ans = new int[nums.Length - k + 1];
            int max = int.MinValue;
            int maxIndex = -1;//记录最大值的index，不需要每次都重新计算最大值，只要比较最右侧新进入的值与当前最大值即可，但是要判断最大值是否还在窗口内
            for(int i = 0; i < ans.Length; i++)
            {
                if(maxIndex < i)
                {
                    max = int.MinValue;
                    for (int j = i; j < i + k; j++)
                    {
                        if(nums[j] > max)
                        {
                            max = nums[j];
                            maxIndex = j;
                        }
                    }
                }
                else
                {
                    int tempIndex = i + k - 1;
                    if (nums[tempIndex] >= max)
                    {
                        max = nums[tempIndex];
                        maxIndex = tempIndex;
                    }
                }
                ans[i] = max;
            }
            return ans;
        }
    }
}
