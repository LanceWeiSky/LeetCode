using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A292 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CanWinNim(int n)
            {
                return (n & 3) != 0;
            }
        }
    }
}
