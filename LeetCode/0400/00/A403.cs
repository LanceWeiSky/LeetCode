using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A403 : IQuestion
    {
        public void Run()
        {
            new Solution().CanCross(new int[] { 0, 1, 3, 6, 7 });
        }

        public class Solution
        {
            public bool CanCross(int[] stones)
            {
                if (stones.Length < 2)
                {
                    return true;
                }
                bool[,] dp = new bool[stones.Length, stones.Length];
                dp[0, 0] = true;
                int max = 1;
                int maxK = 1;
                for (int i = 1; i < stones.Length; i++)
                {
                    if (stones[i] > max)
                    {
                        return false;
                    }
                    for (int j = i - 1; j >= 0; j--)
                    {
                        var distance = stones[i] - stones[j];
                        if (distance > maxK)
                        {
                            break;
                        }
                        for (int k = distance - 1; k <= distance + 1; k++)
                        {
                            if (k >= stones.Length || k < 0)
                            {
                                continue;
                            }
                            dp[i, distance] = dp[j, k];
                            if (dp[i, distance])
                            {
                                if (i == stones.Length - 1)
                                {
                                    return true;
                                }
                                maxK = Math.Max(maxK, distance + 1);
                                max = Math.Max(max, distance + 1 + stones[i]);
                                break;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}
