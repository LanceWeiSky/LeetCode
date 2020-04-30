using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A313 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NthSuperUglyNumber(int n, int[] primes)
            {
                if (primes.Length == 0 || n < 1)
                {
                    return 0;
                }
                int[] dp = new int[n];
                dp[0] = 1;
                int[] p = new int[primes.Length];
                for (int i = 1; i < n; i++)
                {
                    int min = int.MaxValue;
                    List<int> index = new List<int>();
                    for (int j = 0; j < primes.Length; j++)
                    {
                        var temp = dp[p[j]] * primes[j];
                        if (temp < min)
                        {
                            min = temp;
                            index.Clear();
                            index.Add(j);
                        }
                        else if (temp == min)
                        {
                            index.Add(j);
                        }
                    }
                    dp[i] = min;
                    foreach (var j in index)
                    {
                        p[j]++;
                    }
                }
                return dp[n - 1];
            }
        }
    }
}
