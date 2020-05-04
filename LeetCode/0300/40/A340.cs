using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A340 : IQuestion
    {
        public void Run()
        {
            new Solution().LengthOfLongestSubstringKDistinct("eceba", 2);
        }

        public class Solution
        {
            public int LengthOfLongestSubstringKDistinct(string s, int k)
            {
                if (s.Length == 0 || k >= s.Length)
                {
                    return s.Length;
                }
                int length = 0;
                Dictionary<char, IndexInfo> indexes = new Dictionary<char, IndexInfo>();
                SortedSet<IndexInfo> sorted = new SortedSet<IndexInfo>(new IndexComparer());
                int left = 0, right = 0;
                while (right < s.Length)
                {
                    var c = s[right];
                    if (!indexes.TryGetValue(c, out var info))
                    {
                        info = new IndexInfo { Char = c, Index = -1 };
                        indexes.Add(c, info);
                    }
                    if (info.Index >= 0)
                    {
                        sorted.Remove(info);
                    }
                    info.Index = right;
                    sorted.Add(info);
                    if (sorted.Count > k)
                    {
                        length = Math.Max(length, right - left);
                        var min = sorted.Min;
                        sorted.Remove(min);
                        left = min.Index + 1;
                        min.Index = -1;
                        indexes.Remove(min.Char);
                    }
                    right++;
                }
                length = Math.Max(length, right - left);
                return length;
            }

            public class IndexComparer : IComparer<IndexInfo>
            {
                public int Compare(IndexInfo x, IndexInfo y)
                {
                    return x.Index.CompareTo(y.Index);
                }
            }

            public class IndexInfo
            { 
                public char Char { get; set; }
                public int Index { get; set; }
            }
        }
    }
}
