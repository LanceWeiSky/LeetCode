using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A330 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MinPatches(int[] nums, int n)
            {
                long miss = 1;
                int i = 0;
                int patch = 0;
                while (miss <= n)
                {
                    if (i < nums.Length && nums[i] <= miss)
                    {
                        miss += nums[i++];
                    }
                    else
                    {
                        miss += miss;
                        patch++;
                    }
                }
                return patch;
            }
        }
    }
}
