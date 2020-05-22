﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1100._40
{
    class A1143 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LongestCommonSubsequence(string text1, string text2)
            {
                int[,] dp = new int[text1.Length + 1, text2.Length + 1];
                for (int i = 0; i < text1.Length; i++)
                {
                    for (int j = 0; j < text2.Length; j++)
                    {
                        if (text1[i] == text2[j])
                        {
                            dp[i + 1, j + 1] = dp[i, j] + 1;
                        }
                        else
                        {
                            dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                        }
                    }
                }
                return dp[text1.Length, text2.Length];
            }
        }
    }
}
