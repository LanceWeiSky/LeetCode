using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A342 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsPowerOfFour(int num)
            {
                return num > 0 && (num & 0xaaaaaaaa) == 0 && (num & (num - 1)) == 0;
            }
        }
    }
}
