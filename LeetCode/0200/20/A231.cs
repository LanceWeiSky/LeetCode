using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A231 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsPowerOfTwo(int n)
        {
            if (n < 1)
            {
                return false;
            }
            return (n & (n - 1)) == 0;
        }
    }
}
