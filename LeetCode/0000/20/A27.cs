﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A27 : IQuestion
    {
        public void Run()
        {
            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            RemoveElement(nums, 2);
        }

        //给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。

        //不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。

        //元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。



        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/remove-element
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int i = 0;
            int j = nums.Length - 1;
            while (i < j)
            {
                while (i < j && nums[i] != val)
                {
                    i++;
                }
                while (i < j && nums[j] == val)
                {
                    j--;
                }
                if (i < j)
                {
                    nums[i] = nums[j];
                    j--;
                }
            }
            while (j >= 0 && nums[j] == val)
            {
                j--;
            }
            return j + 1;
        }
    }
}
