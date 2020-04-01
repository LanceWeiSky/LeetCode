using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A45 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非负整数数组，你最初位于数组的第一个位置。

        //数组中的每个元素代表你在该位置可以跳跃的最大长度。

        //你的目标是使用最少的跳跃次数到达数组的最后一个位置。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/jump-game-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int Jump(int[] nums)
        {
            int steps = 0;
            int end = 0;
            int max = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                max = Math.Max(max, nums[i] + i);
                if (i == end)
                {
                    end = max;
                    steps++;
                }
            }
            return steps;
        }
    }
}
