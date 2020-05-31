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
                int min = int.MaxValue;
                int max = int.MinValue;
                foreach (var n in nums)
                {
                    min = Math.Min(min, n);
                    max = Math.Max(max, n);
                }
                var root = new Node(min, max);
                foreach (var n in nums)
                {
                    var v = root.Query(n - 1);
                    root.Insert(n, new Value { Length = v.Length + 1, Count = v.Count });
                }
                return root.Value.Count;
            }

            private class Node
            {
                private Node _left;
                private Node _right;

                public int Min { get; }
                public int Max { get; }
                public int Mid { get; }
                public Value Value { get; private set; }

                internal Node(int min, int max)
                {
                    Min = min;
                    Max = max;
                    Mid = min + (max - min) / 2;
                    Value = new Value { Length = 0, Count = 1 };
                }

                public Value Query(int key)
                {
                    if (Max <= key)
                    {
                        return Value;
                    }
                    else if (Min > key)
                    {
                        return new Value { Count = 1 };
                    }
                    else
                    {
                        return Merge(GetLeft().Query(key), GetRight().Query(key));
                    }
                }

                public void Insert(int key, Value v)
                { 
                    if(Min == Max)
                    {
                        Value = Merge(Value, v);
                        return;
                    }
                    if (key <= Mid)
                    {
                        GetLeft().Insert(key, v);
                    }
                    else
                    {
                        GetRight().Insert(key, v);
                    }
                    Value = Merge(GetLeft().Value, GetRight().Value);
                }

                private Value Merge(Value v1, Value v2)
                {
                    if(v1.Length > v2.Length)
                    {
                        return v1;
                    }
                    else if(v1.Length < v2.Length)
                    {
                        return v2;
                    }
                    if(v1.Length == 0)
                    {
                        return new Value { Length = 0, Count = 1 };
                    }
                    return new Value { Length = v2.Length, Count = v1.Count + v2.Count };
                }

                public Node GetLeft()
                {
                    if (_left == null)
                    {
                        _left = new Node(Min, Mid);
                    }
                    return _left;
                }

                public Node GetRight()
                { 
                    if(_right == null)
                    {
                        _right = new Node(Mid + 1, Max);
                    }
                    return _right;
                }
            }

            private class Value
            { 
                public int Length { get; set; }
                public int Count { get; set; }
            }
        }

        public class Solution_1
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
