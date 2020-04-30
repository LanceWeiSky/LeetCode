using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A343 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int IntegerBreak(int n)
            {
                if (n < 4)
                {
                    return n - 1;
                }
                var mod = n % 3;
                var p = n / 3;
                if (mod == 1)
                {
                    return (int)Math.Pow(3, p - 1) * 4;
                }
                else if (mod == 0)
                {
                    return (int)Math.Pow(3, p);
                }
                return (int)Math.Pow(3, p) * 2;
            }
        }
    }
}
