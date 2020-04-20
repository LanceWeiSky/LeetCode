using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A260 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] SingleNumber(int[] nums)
            {
                int bitResult = 0;
                foreach (var n in nums)
                {
                    bitResult ^= n;
                }
                int bit = 1;
                while ((bitResult & bit) == 0)
                {
                    bit <<= 1;
                }

                int r1 = 0;
                int r2 = 0;
                foreach (var n in nums)
                {
                    if ((n & bit) == 0)
                    {
                        r1 ^= n;
                    }
                    else
                    {
                        r2 ^= n;
                    }
                }
                return new int[] { r1, r2 };
            }
        }
    }
}
