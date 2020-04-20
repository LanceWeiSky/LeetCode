using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A201 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            if(m == n)
            {
                return m;
            }
            int i = m ^ n;
            i |= i >> 1;
            i |= i >> 2;
            i |= i >> 4;
            i |= i >> 8;
            i |= i >> 16;
            return m & ~i;
        }
    }
}
