using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A326 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsPowerOfThree(int n)
            {
                return n > 0 && 1162261467 % n == 0;
            }
        }
    }
}
