using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LeetCode._0300._60
{
    class A363 : IQuestion
    {
        public void Run()
        {
            var matrix = JsonSerializer.Deserialize<int[][]>("[[5,-4,-3,4],[-3,-4,4,5],[5,1,5,-4]]");
            var ans = new Solution().MaxSumSubmatrix(matrix, 8);
        }

        public class Solution
        {
            public int MaxSumSubmatrix(int[][] matrix, int k)
            {
                int rows = matrix.Length;
                int cols = matrix[0].Length;
                int max = int.MinValue;
                for (int l = 0; l < cols; l++)
                {
                    int[] rowSum = new int[rows];
                    for (int r = l; r < cols; r++)
                    {
                        for (int row = 0; row < rows; row++)
                        {
                            rowSum[row] += matrix[row][r];
                        }

                        max = Math.Max(max, GetMaxSum(rowSum, k));
                        if (max == k)
                        {
                            return max;
                        }
                    }
                }
                return max;
            }

            private int GetMaxSum(int[] nums, int k)
            {
                int max = int.MinValue;
                int sum = 0;
                foreach (var n in nums)
                {
                    sum = Math.Max(sum + n, n);
                    if (sum > max)
                    {
                        max = sum;
                    }
                }

                if (max <= k)
                {
                    return max;
                }

                SortedSet<int> set = new SortedSet<int>();
                max = int.MinValue;
                sum = 0;
                int distance = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    if (sum == k)
                    {
                        return k;
                    }
                    int lower = sum - k;
                    int upper = lower + distance;
                    if (distance == 0)
                    {
                        upper = set.Max;
                    }
                    if (lower > upper)
                    {
                        set.Add(sum);
                        continue;
                    }
                    var temp = set.GetViewBetween(lower, upper);
                    if (temp.Count > 0)
                    {
                        max = sum - temp.Min;
                        distance = k - max;
                        if (distance == 0)
                        {
                            return max;
                        }
                    }
                    set.Add(sum);
                }
                return max;
            }
        }
    }
}
