using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A414 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int ThirdMax(int[] nums)
            {
                long max = long.MinValue;
                long max2 = long.MinValue;
                long max3 = long.MinValue;
                foreach (var n in nums)
                {
                    if (n > max)
                    {
                        max3 = max2;
                        max2 = max;
                        max = n;
                    }
                    else if (n > max2 && n < max)
                    {
                        max3 = max2;
                        max2 = n;
                    }
                    else if (n > max3 && n < max2)
                    {
                        max3 = n;
                    }
                }
                if (max3 == long.MinValue)
                {
                    return (int)max;
                }
                return (int)max3;
            }
        }
    }
}
