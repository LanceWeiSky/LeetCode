using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A258 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int AddDigits(int num)
            {
                return (num - 1) % 9 + 1;
            }
        }
    }
}
