using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A371 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int GetSum(int a, int b)
            {
                var s = a ^ b;
                b = a & b;
                while (b != 0)
                {
                    b <<= 1;
                    a = s;
                    s = a ^ b;
                    b = a & b;
                }
                return s;
            }
        }
    }
}
