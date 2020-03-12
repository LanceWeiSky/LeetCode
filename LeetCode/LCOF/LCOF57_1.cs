using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF57_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个递增排序的数组和一个数字s，在数组中查找两个数，使得它们的和正好是s。如果有多对数字的和等于s，则输出任意一对即可。

        //思路解析：
        //双指针，一个从左向右遍历，一个从右向左遍历，如果和小于target，left向右移一位，如果和大于target，right向左移一位

        public int[] TwoSum(int[] nums, int target)
        {
            if(nums.Length < 2)
            {
                return new int[0];
            }
            int l = 0;
            int r = nums.Length - 1;
            while(l < r)
            {
                if (target == nums[l] + nums[r])
                {
                    return new int[] { nums[l], nums[r] };
                }
                else if (target > nums[l] + nums[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return new int[0];
        }
    }
}
