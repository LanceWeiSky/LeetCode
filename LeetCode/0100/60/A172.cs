using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A172 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int TrailingZeroes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n /= 5;
                count += n;
            }
            return count;
        }
    }
}
