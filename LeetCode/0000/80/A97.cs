using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A97 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定三个字符串 s1, s2, s3, 验证 s3 是否是由 s1 和 s2 交错组成的。

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s2.Length + s1.Length != s3.Length)
            {
                return false;
            }

            bool[] dp = new bool[s2.Length + 1];
            
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[0] = true;
                    }
                    else if (i == 0)
                    {
                        dp[j] = dp[j - 1] && s3[j - 1] == s2[j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[j] = dp[j] && s3[i - 1] == s1[i - 1];
                    }
                    else
                    {
                        dp[j] = dp[j - 1] && s3[i + j - 1] == s2[j - 1] || dp[j] && s3[i + j - 1] == s1[i - 1];
                    }
                }
            }

            return dp[s2.Length];
        }
    }
}
