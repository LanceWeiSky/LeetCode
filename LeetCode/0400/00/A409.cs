using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A409 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                int[] chars = new int[128];
                foreach (var c in s)
                {
                    chars[c]++;
                }
                int ans = 0;
                foreach (var c in chars)
                {
                    if (c % 2 == 0)
                    {
                        ans += c;
                    }
                    else
                    {
                        ans += c - 1;
                        if (ans % 2 == 0)
                        {
                            ans++;
                        }
                    }
                }
                return ans;
            }
        }
    }
}
