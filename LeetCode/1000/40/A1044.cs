using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._1000._40
{
    class A1044 : IQuestion
    {
        public void Run()
        {
            new Solution().LongestDupSubstring("banana");
        }

        public class Solution
        {
            public string LongestDupSubstring(string S)
            {
                int left = 1;
                int right = S.Length - 1;
                string ans = "";
                long mod = uint.MaxValue;
                while (left <= right)
                {
                    int length = left + (right - left) / 2;
                    var temp = Search(length, S, mod);
                    if (!string.IsNullOrEmpty(temp))
                    {
                        left = length + 1;
                        ans = temp;
                    }
                    else
                    {
                        right = length - 1;
                    }
                }
                return ans;
            }

            private string Search(int length, string s, long mod)
            {
                Dictionary<long, List<int>> hash = new Dictionary<long, List<int>>(s.Length - length);
                long al = 1;
                long h = 0;
                for (int i = 0; i < length; i++)
                {
                    h = (h * 26) % mod + s[i] - 'a';
                    al = (al * 26) % mod;
                }
                hash.Add(h, new List<int> { 0 });
                for (int i = 1; i < s.Length - length + 1; i++)
                {
                    h = (h * 26 - (s[i - 1] - 'a') * al % mod + mod + s[i + length - 1] - 'a') % mod;
                    if (hash.TryGetValue(h, out var list))
                    {
                        var temp = s.Substring(i, length);
                        if(list.Any(index => s.Substring(index, length) == temp))
                        {
                            return temp;
                        }
                        list.Add(i);
                    }
                    else
                    {
                        hash.Add(h, new List<int> { i });
                    }
                }
                return string.Empty;
            }
        }
    }
}
