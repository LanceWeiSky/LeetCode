using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF21 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个整数数组，实现一个函数来调整该数组中数字的顺序，使得所有奇数位于数组的前半部分，所有偶数位于数组的后半部分。

        public class Solution
        {

            //思路解析：
            //双指针法，不需要额外的空间，直接在原数组修改。
            //1.两个指针一个从左到右，另一个从右到左
            //2.左边的指针找偶数，右边的指针找基数，找到后调换位置，直到两指针相遇。

            public int[] Exchange(int[] nums)
            {
                int left = 0;
                int right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[right] % 2 == 0)
                    {
                        right--;
                        continue;
                    }
                    if (nums[left] % 2 == 0)
                    {
                        var temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    left++;
                }
                return nums;
            }

            public int[] Exchange_1(int[] nums)
            {
                int[] ans = new int[nums.Length];
                int i = 0;
                int j = ans.Length - 1;
                for (int k = 0; k < nums.Length; k++)
                {
                    if (nums[k] % 2 == 0)
                    {
                        ans[j] = nums[k];
                        j--;
                    }
                    else
                    {
                        ans[i] = nums[k];
                        i++;
                    }
                }
                return ans;
            }
        }
    }
}
