using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0600._60
{
    class A673 : IQuestion
    {
        public void Run()
        {
            new Solution().FindNumberOfLIS(new int[] { 1, 4, 1, 3, 1, -14, 1, -13 });
        }

        public class Solution
        {
            public int FindNumberOfLIS(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }
                int index = 0;
                NumberList[] dp = new NumberList[nums.Length];
                dp[0] = new NumberList();
                dp[0].Add(nums[0], 1);
                for (int i = 1; i < nums.Length; i++)
                {
                    NumberList temp = new NumberList();
                    temp.Add(nums[i], 1);
                    if (nums[i] > dp[index].List.Last().Num)
                    {
                        temp.List.Last().Count = dp[index].GetCount(new NumberInfo { Num = nums[i], Count = int.MaxValue });
                        index++;
                        dp[index] = temp;
                    }
                    else
                    {
                        var idx = Array.BinarySearch(dp, 0, index + 1, temp, new NumberListComparer());
                        if (idx < 0)
                        {
                            idx = ~idx;
                        }
                        int count = 1;
                        if (idx > 0)
                        {
                            count = dp[idx - 1].GetCount(new NumberInfo { Num = nums[i], Count = int.MaxValue });
                        }
                        dp[idx].Add(nums[i], count);
                    }
                }
                return dp[index].List.Last().Count;
            }

            private class NumberList
            {
                public List<NumberInfo> List { get; } = new List<NumberInfo>();

                public void Add(int num, int count)
                {
                    if (List.Count > 0)
                    {
                        count += List.Last().Count;
                    }
                    NumberInfo info = new NumberInfo { Num = num, Count = count };
                    List.Add(info);
                }

                public int GetCount(NumberInfo info)
                {
                    var index = List.BinarySearch(info, new NumberComparer());
                    if (index < 0)
                    {
                        index = ~index;
                    }
                    else
                    {
                        index++;
                    }
                    var count = List.Last().Count;
                    if (index > 0)
                    {
                        count -= List[index - 1].Count;
                    }
                    return count;
                }
            }

            private class NumberListComparer : Comparer<NumberList>
            {
                public override int Compare(NumberList x, NumberList y)
                {
                    return x.List.Last().Num.CompareTo(y.List.Last().Num);
                }
            }

            private class NumberInfo
            {
                public int Num { get; set; }
                public int Count { get; set; }
            }

            private class NumberComparer : IComparer<NumberInfo>
            {

                internal NumberComparer()
                {
                }

                public int Compare(NumberInfo x, NumberInfo y)
                {
                    var c = y.Num.CompareTo(x.Num);
                    if (c == 0)
                    {
                        c = x.Count.CompareTo(y.Count);
                    }
                    return c;
                }
            }
        }
    }
}
