using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A334 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IncreasingTriplet(int[] nums)
            {
                int small = int.MaxValue;
                int mid = int.MaxValue;
                foreach (var n in nums)
                {
                    if (n > mid)
                    {
                        return true;
                    }
                    else if (n > small)
                    {
                        mid = n;
                    }
                    else
                    {
                        small = n;
                    }
                }
                return false;
            }
        }
    }
}
