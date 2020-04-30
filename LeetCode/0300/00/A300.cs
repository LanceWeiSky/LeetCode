using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A300 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
        }

        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                if (nums.Length < 2)
                {
                    return nums.Length;
                }
                int index = 0;
                int[] dp = new int[nums.Length];//dp[i]表示所有长度为i + 1的子序列结尾最小值
                dp[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] > dp[index])
                    {
                        dp[++index] = nums[i];
                    }
                    else
                    {
                        int left = 0;
                        int right = index;
                        while (left <= right)
                        {
                            int pivot = left + (right - left) / 2;
                            if (dp[pivot] > nums[i])
                            {
                                right = pivot - 1;
                            }
                            else if (dp[pivot] == nums[i])
                            {
                                left = pivot;
                                break;
                            }
                            else
                            {
                                left = pivot + 1;
                            }
                        }
                        dp[left] = nums[i];
                    }
                }
                return index + 1;
            }
        }
    }
}
