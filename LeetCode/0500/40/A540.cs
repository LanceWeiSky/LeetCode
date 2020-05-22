using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A540 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int SingleNonDuplicate(int[] nums)
            {
                int left = 0;
                int right = nums.Length - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if ((mid & 1) == 1)
                    {
                        if (mid > 0 && nums[mid - 1] == nums[mid])
                        {
                            left = mid + 1;
                        }
                        else if (mid < nums.Length - 1 && nums[mid] == nums[mid + 1])
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            return nums[mid];
                        }
                    }
                    else
                    {
                        if (mid > 0 && nums[mid - 1] == nums[mid])
                        {
                            right = mid - 1;
                        }
                        else if (mid < nums.Length - 1 && nums[mid] == nums[mid + 1])
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            return nums[mid];
                        }
                    }
                }
                return nums[left];
            }
        }
    }
}
