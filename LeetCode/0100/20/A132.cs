using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A132 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
        //返回符合要求的最少分割次数。

        public int MinCut(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                InitializeDP(s, i, i, dp);
                InitializeDP(s, i, i + 1, dp);
            }
            int[] dpCount = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            { 
                if(dp[0, i])
                {
                    dpCount[i] = 0;
                    continue;
                }
                dpCount[i] = i;
                for (int j = 0; j < i; j++)
                {
                    if (dp[j + 1, i])
                    {
                        dpCount[i] = Math.Min(dpCount[i], dpCount[j] + 1);
                    }
                }
            }
            return dpCount[s.Length - 1];
        }

        private void InitializeDP(string s, int left, int right, bool[,] dp)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] == s[right])
                {
                    dp[left--, right++] = true;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
