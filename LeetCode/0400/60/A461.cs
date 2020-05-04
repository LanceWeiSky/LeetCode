using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._60
{
    class A461 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int HammingDistance(int x, int y)
            {
                int temp = x ^ y;
                int count = 0;
                while (temp != 0)
                {
                    temp &= temp - 1;
                    count++;
                }
                return count;
            }
        }
    }
}
