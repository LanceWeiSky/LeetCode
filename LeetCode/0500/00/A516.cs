using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._00
{
    class A516 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LongestPalindromeSubseq(string s)
            {
                if (s.Length < 2)
                {
                    return s.Length;
                }
                int[,] dp = new int[s.Length, s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    dp[i, i] = 1;
                }
                for (int i = s.Length - 2; i >= 0; i--)
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[i] == s[j])
                        {
                            dp[i, j] = dp[i + 1, j - 1] + 2;
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                        }
                    }
                }
                return dp[0, s.Length - 1];
            }
        }
    }
}
