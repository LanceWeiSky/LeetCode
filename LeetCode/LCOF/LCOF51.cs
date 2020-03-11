using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF51 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //在数组中的两个数字，如果前面一个数字大于后面的数字，则这两个数字组成一个逆序对。输入一个数组，求出这个数组中的逆序对的总数。

        public int ReversePairs(int[] nums)
        {
            if(nums.Length == 0)
            {
                return 0;
            }
            return ReversePairs(nums, 0, nums.Length - 1, new int[nums.Length]);
        }

        //归并排序思想，边计数边排序
        private int ReversePairs(int[] nums, int left, int right, int[] temp)
        {
            if (left == right)
            {
                return 0;
            }
            int mid = (left + right) / 2;
            int leftCount = ReversePairs(nums, left, mid, temp);
            int rightCount = ReversePairs(nums, mid + 1, right, temp);
            if (nums[mid] < nums[mid + 1])//左边的数比右边的全都小，说明没有需要归并处理的逆序对
            {
                return leftCount + rightCount;
            }
            int index = 0;
            int i = left;
            int j = mid + 1;
            int count = 0;
            while (i <= mid && j <= right)
            {
                if (nums[i] > nums[j])//i,j是逆序对，并且i~mid全都比i大，也就比j大，所以i~mid全都是逆序对，逆序对的数量加mid-i+1
                {
                    temp[index++] = nums[j++];
                    count += mid - i + 1;
                }
                else
                {
                    temp[index++] = nums[i++];
                }
            }
            while (i <= mid)
            {
                temp[index++] = nums[i++];
            }
            while (j <= right)
            {
                temp[index++] = nums[j++];
            }
            Array.Copy(temp, 0, nums, left, index);
            return count + leftCount + rightCount;
        }
    }
}
