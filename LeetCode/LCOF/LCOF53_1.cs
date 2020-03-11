using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF53_1 : IQuestion
    {
        public void Run()
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 5;
            var ans = Search(nums, target);
        }

        //统计一个数字在排序数组中出现的次数。

        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int left = 0;
            int right = nums.Length - 1;
            int mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    break;
                }
            }

            if (nums[mid] != target)
            {
                return 0;
            }

            int leftRight = mid;
            int rightLeft = mid + 1;

            while (left < leftRight)//找到最左侧的target
            {
                mid = (left + leftRight) / 2;
                if (nums[mid] == target)
                {
                    leftRight = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            while (rightLeft < right)//找到target右侧第一个比target大的数
            {
                mid = (right + rightLeft) / 2;
                if (nums[mid] == target)
                {
                    rightLeft = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if(nums[right] == target)//Length - 1边界情况
            {
                right++;
            }
            return right - left;
        }
    }
}
