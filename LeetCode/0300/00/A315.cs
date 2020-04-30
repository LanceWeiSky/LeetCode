using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._00
{
    class A315 : IQuestion
    {
        public void Run()
        {
            new Solution().CountSmaller(new int[] { 5, 2, 6, 1 });
        }

        public class Solution
        {
            private int[] _indexes;
            private int[] _temp;
            private int[] _counter;

            public IList<int> CountSmaller(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return new List<int>();
                }
                _indexes = new int[nums.Length];
                _temp = new int[nums.Length];
                _counter = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    _indexes[i] = i;
                }
                DivideMergeSort(nums, 0, nums.Length - 1);
                return _counter.ToList();
            }

            private void DivideMergeSort(int[] nums, int left, int right)
            {
                if (left == right)
                {
                    return;
                }
                int pivot = left + (right - left) / 2;
                DivideMergeSort(nums, left, pivot);
                DivideMergeSort(nums, pivot + 1, right);

                if (nums[_indexes[pivot]] > nums[_indexes[pivot + 1]])
                {
                    Merge(nums, left, pivot, right);
                }
            }

            private void Merge(int[] nums, int left, int pivot, int right)
            {
                int i = left;
                int j = pivot + 1;
                int index = 0;
                while (i <= pivot && j <= right)
                {
                    if (nums[_indexes[i]] <= nums[_indexes[j]])
                    {
                        _counter[_indexes[i]] += j - pivot - 1;
                        _temp[index++] = _indexes[i++];
                    }
                    else
                    {
                        _temp[index++] = _indexes[j++];
                    }
                }
                while (i <= pivot)
                {
                    _counter[_indexes[i]] += right - pivot;
                    _temp[index++] = _indexes[i++];
                }
                while (j <= right)
                {
                    _temp[index++] = _indexes[j++];
                }

                Array.Copy(_temp, 0, _indexes, left, index);
            }
        }
    }
}
