using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A327 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().CountRangeSum(new int[] { -2147483647, 0, -2147483647, 2147483647 }, -564, 3864);
        }

        public class Solution
        {
            public int CountRangeSum(int[] nums, int lower, int upper)
            {
                long[] sums = new long[nums.Length + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    sums[i + 1] = sums[i] + nums[i];
                }

                return DivideMerge(sums, 0, sums.Length - 1, new long[sums.Length], lower, upper);
            }

            private int DivideMerge(long[] nums, int left, int right, long[] temp, int lower, int upper)
            {
                if (left == right)
                {
                    return 0;
                }
                int pivot = left + (right - left) / 2;
                var leftCount = DivideMerge(nums, left, pivot, temp, lower, upper);
                var rightCount = DivideMerge(nums, pivot + 1, right, temp, lower, upper);

                int count = leftCount + rightCount;
                int lIndex = pivot + 1;
                int uIndex = lIndex;
                for (int i = left; i <= pivot; i++)
                {
                    while (lIndex <= right && nums[lIndex] - nums[i] < lower)
                    {
                        lIndex++;
                    }
                    if (uIndex < lIndex)
                    {
                        uIndex = lIndex;
                    }
                    while (uIndex <= right && nums[uIndex] - nums[i] <= upper)
                    {
                        uIndex++;
                    }
                    count += uIndex - lIndex;
                }

                if (nums[pivot] <= nums[pivot + 1])
                {
                    return count;
                }

                int l = left;
                int r = pivot + 1;
                int index = 0;
                while (l <= pivot && r <= right)
                {
                    if (nums[l] < nums[r])
                    {
                        temp[index++] = nums[l++];
                    }
                    else
                    {
                        temp[index++] = nums[r++];
                    }
                }
                while (l <= pivot)
                {
                    temp[index++] = nums[l++];
                }
                while (r <= right)
                {
                    temp[index++] = nums[r++];
                }
                Array.Copy(temp, 0, nums, left, index);
                return count;
            }
        }
    }
}
