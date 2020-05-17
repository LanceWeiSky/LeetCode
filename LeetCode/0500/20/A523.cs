using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._20
{
    class A523 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CheckSubarraySum(int[] nums, int k)
            {
                if (nums.Length < 2)
                {
                    return false;
                }
                Dictionary<int, int> map = new Dictionary<int, int>();
                map.Add(0, -1);
                int sum = 0;
                for(int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    if (k != 0)
                    {
                        sum %= k;
                    }
                    if (map.TryGetValue(sum, out var index))
                    {
                        if (i - index > 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        map.Add(sum, i);
                    }
                }
                return false;
            }
        }
    }
}
