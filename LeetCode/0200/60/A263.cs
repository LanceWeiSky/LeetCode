using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A263 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsUgly(int num)
            {
                while (num > 1)
                {
                    if (num % 5 == 0)
                    {
                        num /= 5;
                    }
                    else if (num % 3 == 0)
                    {
                        num /= 3;
                    }
                    else if (num % 2 == 0)
                    {
                        num /= 2;
                    }
                    else
                    {
                        return false;
                    }
                }
                return num == 1;
            }
        }
    }
}
