using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A357 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CountNumbersWithUniqueDigits(int n)
            {
                if(n == 0)
                {
                    return 0;
                }
                if (n == 1)
                {
                    return 10;
                }
                int count = 81;
                int sum = 91;
                for (int i = 3; i <= n; i++)
                {
                    count = count * (10 - i + 1);
                    sum += count;
                }
                return sum;
            }
        }
    }
}
