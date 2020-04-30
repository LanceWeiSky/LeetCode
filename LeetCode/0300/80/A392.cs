using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A392 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsSubsequence(string s, string t)
            {
                int[,] dp = new int[t.Length + 1, 26];
                for (int i = 0; i < 26; i++)
                {
                    int next = -1;
                    for (int j = t.Length - 1; j >= 0; j--)
                    {
                        dp[j + 1, i] = next;
                        if (t[j] - 'a' == i)
                        {
                            next = j + 1;
                        }
                    }
                    dp[0, i] = next;
                }
                int p = 0;
                foreach (var c in s)
                {
                    p = dp[p, c - 'a'];
                    if (p < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
