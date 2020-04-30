using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A338 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] CountBits(int num)
            {
                int[] count = new int[num + 1];
                for (int i = 1; i <= num; i++)
                {
                    count[i] = count[i & (i - 1)] + 1;
                }
                return count;
            }
        }
    }
}
