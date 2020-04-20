using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A241 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> DiffWaysToCompute(string input)
            {
                List<char> signs = new List<char>();
                List<int> nums = new List<int>();
                StringBuilder builder = new StringBuilder();
                foreach (var c in input)
                {
                    if (c == '+' || c == '-' || c == '*')
                    {
                        signs.Add(c);
                        nums.Add(int.Parse(builder.ToString()));
                        builder.Clear();
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
                if (builder.Length > 0)
                {
                    nums.Add(int.Parse(builder.ToString()));
                }

                return DivideMerge(signs, nums, 0, nums.Count - 1, new Dictionary<string, List<int>>());
            }

            private List<int> DivideMerge(List<char> signs, List<int> nums, int left, int right, Dictionary<string, List<int>> cache)
            {
                if (cache.TryGetValue($"{left}_{right}", out var ans))
                {
                    return ans;
                }
                if (left == right)
                {
                    return new List<int> { nums[left] };
                }
                ans = new List<int>();

                for (int i = left; i < right; i++)
                {
                    int s = signs[i];
                    var leftValues = DivideMerge(signs, nums, left, i, cache);
                    var rightValues = DivideMerge(signs, nums, i + 1, right, cache);

                    foreach (var lv in leftValues)
                    {
                        foreach (var rv in rightValues)
                        {
                            if (s == '+')
                            {
                                ans.Add(lv + rv);
                            }
                            else if (s == '-')
                            {
                                ans.Add(lv - rv);
                            }
                            else
                            {
                                ans.Add(lv * rv);
                            }
                        }
                    }
                }
                cache[$"{left}_{right}"] = ans;
                return ans;
            }

        }
    }
}
