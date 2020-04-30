using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A389 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public char FindTheDifference(string s, string t)
            {
                int[] counter = new int[26];
                foreach (var c in s)
                {
                    counter[c - 'a']++;
                }
                foreach (var c in t)
                {
                    if (counter[c - 'a'] == 0)
                    {
                        return c;
                    }
                    counter[c - 'a']--;
                }
                return '\0';
            }
        }
    }
}
