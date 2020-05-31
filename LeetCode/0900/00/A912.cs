using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._00
{
    class A912 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private readonly Random _rnd = new Random();

            public int[] SortArray(int[] nums)
            {
                DivideMergeSort(nums);
                return nums;
            }

            private void QuickSort(int[] nums)
            {
                QuickSort(nums, 0, nums.Length - 1);
            }

            private void QuickSort(int[] nums, int left, int right)
            {
                if (left < right)
                {
                    var p = RandomizedPartition(nums, left, right);
                    QuickSort(nums, left, p - 1);
                    QuickSort(nums, p + 1, right);
                }
            }

            private int RandomizedPartition(int[] nums, int left, int right)
            {
                Swap(nums, _rnd.Next(left, right + 1), right);
                return Partition(nums, left, right);
            }

            private int Partition(int[] nums, int left, int right)
            {
                var pivot = nums[right];
                int index = left;
                for (int i = left; i <= right; i++)
                {
                    if (nums[i] <= pivot)
                    {
                        Swap(nums, index++, i);
                    }
                }
                return index - 1;
            }

            private void Swap(int[] nums, int i, int j)
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            private void HeapSort(int[] nums)
            {
                BuildHeap(nums);
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    Swap(nums, 0, i);
                    ShiftDown(nums, 0, i);
                }
            }

            private void ShiftDown(int[] nums, int index, int length)
            {
                while (index < length)
                {
                    int leftSon = (index << 1) + 1;
                    int rightSon = (index << 1) + 2;
                    int maxIndex = index;
                    if (leftSon < length && nums[leftSon] > nums[maxIndex])
                    {
                        maxIndex = leftSon;
                    }
                    if (rightSon < length && nums[rightSon] > nums[maxIndex])
                    {
                        maxIndex = rightSon;
                    }
                    if (maxIndex != index)
                    {
                        Swap(nums, maxIndex, index);
                        index = maxIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void BuildHeap(int[] nums)
            {
                int maxNonLeafIndex = (nums.Length - 1) >> 1;
                for (int i = maxNonLeafIndex; i >= 0; i--)
                {
                    ShiftDown(nums, i, nums.Length);
                }
            }

            private void DivideMergeSort(int[] nums)
            {
                DivideMerge(nums, 0, nums.Length - 1, new int[nums.Length]);
            }

            private void DivideMerge(int[] nums, int left, int right, int[] temp)
            {
                if (left == right)
                {
                    return;
                }
                int mid = left + ((right - left) >> 1);
                DivideMerge(nums, left, mid, temp);
                DivideMerge(nums, mid + 1, right, temp);
                int i = left;
                int j = mid + 1;
                int length = right - left + 1;
                for (int k = 0; k < length; k++)
                {
                    if (i <= mid && j <= right)
                    {
                        if (nums[i] < nums[j])
                        {
                            temp[k] = nums[i++];
                        }
                        else
                        {
                            temp[k] = nums[j++];
                        }
                    }
                    else if (i <= mid)
                    {
                        temp[k] = nums[i++];
                    }
                    else if (j <= right)
                    {
                        temp[k] = nums[j++];
                    }
                }
                Array.Copy(temp, 0, nums, left, length);
            }
        }
    }
}
