using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A423 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string OriginalDigits(string s)
            {
                int[] counter = new int[26];
                foreach (var c in s)
                {
                    counter[c - 'a']++;
                }
                int[] nums = new int[10];
                nums[0] = counter['z' - 'a'];
                nums[2] = counter['w' - 'a'];
                nums[4] = counter['u' - 'a'];
                nums[6] = counter['x' - 'a'];
                nums[8] = counter['g' - 'a'];
                nums[3] = counter['h' - 'a'] - nums[8];
                nums[5] = counter['f' - 'a'] - nums[4];
                nums[7] = counter['s' - 'a'] - nums[6];
                nums[9] = counter['i' - 'a'] - nums[5] - nums[6] - nums[8];
                nums[1] = counter['n' - 'a'] - nums[7] - nums[9] * 2;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        builder.Append((char)(i + '0'), nums[i]);
                    }
                }
                return builder.ToString();
            }
        }
    }
}
