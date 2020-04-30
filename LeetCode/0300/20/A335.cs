using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A335 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsSelfCrossing(int[] x)
            {
                for (int i = 3; i < x.Length; i++)
                {
                    if (x[i] >= x[i - 2] && x[i - 1] <= x[i - 3])
                    {
                        return true;
                    }
                    if (i > 3 && x[i] + x[i - 4] >= x[i - 2] && x[i - 1] == x[i - 3])
                    {
                        return true;
                    }
                    if (i > 4 && x[i] + x[i - 4] >= x[i - 2] && x[i - 1] + x[i - 5] >= x[i - 3] && x[i - 2] > x[i - 4] && x[i - 3] > x[i - 1])
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
