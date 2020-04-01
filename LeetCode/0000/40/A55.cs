using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A55 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非负整数数组，你最初位于数组的第一个位置。
        //数组中的每个元素代表你在该位置可以跳跃的最大长度。
        //判断你是否能够到达最后一个位置。

        public bool CanJump(int[] nums)
        {
            int max = 0;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                max = Math.Max(max, i + nums[i]);
                if (max == i)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
