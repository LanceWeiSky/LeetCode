﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A219 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool ContainsNearbyDuplicate(int[] nums, int k)
            {
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > k)
                    {
                        set.Remove(nums[i - k - 1]);
                    }
                    if (!set.Add(nums[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
