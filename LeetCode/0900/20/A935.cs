using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._20
{
    class A935 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int KnightDialer(int N)
            {
                int mod = (int)1e9 + 7;
                if (N == 1)
                {
                    return 10;
                }
                int[] dp = new int[10];
                Array.Fill(dp, 1);
                List<int>[] nexts = new List<int>[] {
                    new List<int>{ 4, 6 },
                    new List<int>{ 6, 8 },
                    new List<int>{ 7, 9 },
                    new List<int>{ 4, 8 },
                    new List<int>{ 0, 3, 9 },
                    new List<int>{ },
                    new List<int>{ 0, 1, 7 },
                    new List<int>{ 2, 6 },
                    new List<int>{ 1, 3 },
                    new List<int>{ 2, 4 },
                };
                for (int i = 1; i < N; i++)
                {
                    int[] temp = new int[10];
                    for (int j = 0; j < nexts.Length; j++)
                    {
                        foreach (var next in nexts[j])
                        {
                            temp[next] = (temp[next] + dp[j]) % mod;
                        }
                    }
                    dp = temp;
                }
                int count = 0;
                foreach (var c in dp)
                {
                    count = (count + c) % mod;
                }
                return count;
            }
        }
    }
}
