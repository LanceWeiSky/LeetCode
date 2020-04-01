using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A35 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
        //你可以假设数组中无重复元素。

        public int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}
