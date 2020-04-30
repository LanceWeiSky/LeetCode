using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A376 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int WiggleMaxLength(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }
                int down = 1;
                int up = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] > nums[i - 1])
                    {
                        up = down + 1;
                    }
                    else if (nums[i] < nums[i - 1])
                    {
                        down = up + 1;
                    }
                }
                return Math.Max(up, down);
            }
        }
    }
}
