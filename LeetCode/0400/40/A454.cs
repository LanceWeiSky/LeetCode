using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A454 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
            {
                int n = A.Length;
                Dictionary<int, int> counter = new Dictionary<int, int>(n * n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var sum = A[i] + B[j];
                        if (counter.TryGetValue(sum, out var count))
                        {
                            counter[sum] = count + 1;
                        }
                        else
                        {
                            counter.Add(sum, 1);
                        }
                    }
                }
                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var sum = -C[i] - D[j];
                        if (counter.TryGetValue(sum, out var count))
                        {
                            ans += count;
                        }
                    }
                }
                return ans;
            }
        }
    }
}
