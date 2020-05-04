using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A421 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FindMaximumXOR(int[] nums)
            {
                int mask = 0;
                int res = 0;
                for (int i = 30; i >= 0; i--)
                { 
                    mask |= 1 << i;
                    HashSet<int> set = new HashSet<int>(nums.Length);
                    foreach (var n in nums)
                    {
                        set.Add(n & mask);
                    }

                    int temp = res | 1 << i;
                    foreach (var prefix in set)
                    {
                        if (set.Contains(prefix ^ temp))
                        {
                            res = temp;
                            break;
                        }
                    }
                }
                return res;
            }
        }
    }
}
