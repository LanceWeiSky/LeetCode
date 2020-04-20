using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A215 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int FindKthLargest(int[] nums, int k)
        {
            int left = 0;
            int right = nums.Length - 1;
            int p = nums.Length;
            while (p != k - 1)
            {
                if (p > k - 1)
                {
                    right = p - 1;
                }
                else
                {
                    left = p + 1;
                }
                p = Partition(nums, left, right);
            }
            return nums[p];
        }

        private int Partition(int[] nums, int left, int right)
        {
            int temp = nums[left];
            while (left < right)
            {
                while (left < right && nums[right] < temp)
                {
                    right--;
                }
                if (left < right)
                {
                    nums[left] = nums[right];
                }
                while (left < right && nums[left] >= temp)
                {
                    left++;
                }
                if (left < right)
                {
                    nums[right] = nums[left];
                }
            }
            nums[left] = temp;
            return left;
        }
    }
}
