using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A400 : IQuestion
    {
        public void Run()
        {
            new Solution().FindNthDigit(1000000000);
        }

        public class Solution
        {
            public int FindNthDigit(int n)
            {
                n--;
                int firstNumber = 1;
                for (int i = 1; i < 10; i++)
                {
                    if (i == 9 || n < 9 * firstNumber * i)
                    {
                        var num = firstNumber + n / i;
                        var length = i - 1 - n % i;
                        for (int j = 0; j < length; j++)
                        {
                            num /= 10;
                        }
                        return num % 10;
                    }
                    n -= 9 * firstNumber * i;
                    firstNumber *= 10;
                }
                return -1;
            }
        }
    }
}
