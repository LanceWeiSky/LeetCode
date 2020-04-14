using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A191 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                n &= n - 1;
                count++;
            }
            return count;
        }
    }
}
