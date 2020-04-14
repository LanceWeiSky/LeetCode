using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A198 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int Rob(int[] nums)
        {
            int prevMax = 0;
            int curMax = 0;
            foreach (var n in nums)
            {
                var temp = curMax;
                curMax = Math.Max(prevMax + n, curMax);
                prevMax = temp;
            }
            return curMax;
        }
    }
}
