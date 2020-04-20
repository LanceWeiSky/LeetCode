using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A283 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public void MoveZeroes(int[] nums)
            {
                int zeroIndex = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[zeroIndex++] = nums[i];
                        nums[i] = 0;
                    }
                }
            }
        }
    }
}
