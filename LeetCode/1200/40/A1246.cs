using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._40
{
    class A1246 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MinimumMoves(int[] arr)
            {
                int[,] dp = new int[arr.Length, arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    dp[i, i] = 1;
                }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] == arr[i + 1])
                    {
                        dp[i, i + 1] = 1;
                    }
                    else
                    {
                        dp[i, i + 1] = 2;
                    }
                }
                for (int length = 2; length < arr.Length; length++)
                {
                    for (int i = 0; i < arr.Length - length; i++)
                    {
                        int j = length + i;
                        dp[i, j] = length + 1;
                        for (int k = i; k < j; k++)
                        {
                            dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j]);
                        }
                        if (arr[i] == arr[j])
                        {
                            dp[i, j] = Math.Min(dp[i, j], dp[i + 1, j - 1]);
                        }
                    }
                }
                return dp[0, arr.Length - 1];
            }
        }
    }
}
