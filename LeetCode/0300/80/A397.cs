using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A397 : IQuestion
    {
        public void Run()
        {
            new Solution().IntegerReplacement(int.MaxValue);
        }

        public class Solution
        {
            public int IntegerReplacement(int n)
            {
                int count = 0;
                int mask = 0x7fffffff;
                while (n != 1)
                {
                    if ((n & 1) == 0)
                    {
                        n >>= 1;
                        n &= mask;
                    }
                    else
                    {
                        if ((n & 2) == 2 && n != 3)
                        {
                            n++;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    count++;
                }
                return count;
            }
        }
    }
}
