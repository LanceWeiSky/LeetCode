using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LeetCode._0300._20
{
    class A324 : IQuestion
    {
        public void Run()
        {
            new Solution().WiggleSort(new int[] { 4, 5, 5, 5, 5, 6, 6, 6 });
        }

        public class Solution
        {
            public void WiggleSort(int[] nums)
            {
                int mid = nums.Length / 2;
                QuickSelect(nums, 0, nums.Length - 1, mid);
                int midValue = nums[mid];

                int i = 0;
                int j = 0;
                int k = nums.Length - 1;
                while (j <= k)
                {
                    var vj = GetVirtualAddress(j, nums.Length);
                    if (nums[vj] < midValue)
                    {
                        Swap(nums, vj, GetVirtualAddress(k, nums.Length));
                        k--;
                    }
                    else if (nums[vj] > midValue)
                    {
                        Swap(nums, vj, GetVirtualAddress(i, nums.Length));
                        i++;
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            private void QuickSelect(int[] nums, int start, int end, int n)
            {
                int i = start;
                int j = start;
                int temp = nums[end];
                while (j <= end)
                {
                    if (nums[j] <= temp)
                    {
                        Swap(nums, i++, j++);
                    }
                    else
                    {
                        j++;
                    }
                }
                if (i - 1 < n)
                {
                    QuickSelect(nums, i, end, n);
                }
                else if (i - 1 > n)
                {
                    QuickSelect(nums, start, i - 2, n);
                }
            }

            private void Swap(int[] nums, int i, int j)
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            private int GetVirtualAddress(int vi, int length)
            {
                return (vi * 2 + 1) % (length | 1);
            }
        }
    }
}
