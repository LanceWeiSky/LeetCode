using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace LeetCode._0300._20
{
    class A336 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().PalindromePairs(new string[] { "a", "abc", "aba", "" });
        }

        public class Solution
        {
            public IList<IList<int>> PalindromePairs(string[] words)
            {
                if (words.Length < 2)
                {
                    return new List<IList<int>>();
                }
                Dictionary<string, int> map = new Dictionary<string, int>(words.Length);
                for (int i = 0; i < words.Length; i++)
                {
                    map[words[i]] = i;
                }
                List<IList<int>> ans = new List<IList<int>>();
                foreach (var m in map)
                {
                    var prefixes = GetSubStrings(m.Key, true);
                    foreach (var p in prefixes)
                    {
                        if (map.TryGetValue(p, out var i) && i != m.Value)
                        {
                            ans.Add(new int[] { m.Value, i });
                        }
                    }
                    var suffixes = GetSubStrings(m.Key, false);
                    foreach (var s in suffixes)
                    {
                        if (s.Length == m.Key.Length)
                        {
                            continue;
                        }
                        if (map.TryGetValue(s, out var i) && i != m.Value)
                        {
                            ans.Add(new int[] { i, m.Value });
                        }
                    }
                }
                return ans;
            }

            private HashSet<string> GetSubStrings(string word, bool isPrefix)
            {
                HashSet<string> subStrings = new HashSet<string>();
                StringBuilder builder = new StringBuilder("$#");
                foreach (var c in word)
                {
                    builder.Append(c);
                    builder.Append('#');
                }
                builder.Append('^');
                string s = builder.ToString();
                int[] p = new int[s.Length];
                int id = 0;
                int max = 0;
                for (int i = 1; i < s.Length - 1; i++)
                {
                    if (i < max)
                    {
                        p[i] = Math.Min(max - i, p[id * 2 - i]);
                    }
                    while (s[i + p[i]] == s[i - p[i]])
                    {
                        p[i]++;
                    }
                    if (p[i] + i > max)
                    {
                        max = p[i] + i;
                        id = i;
                    }
                    if (isPrefix)
                    {
                        if (p[i] + i == s.Length - 1)
                        {
                            int endIndex = word.Length - p[i];
                            StringBuilder builder2 = new StringBuilder();
                            for (int j = endIndex; j >= 0; j--)
                            {
                                builder2.Append(word[j]);
                            }
                            subStrings.Add(builder2.ToString());
                        }
                    }
                    else
                    {
                        if (i - p[i] == 0)
                        {
                            int endIndex = p[i] - 1;
                            StringBuilder builder2 = new StringBuilder();
                            for (int j = word.Length - 1; j >= endIndex; j--)
                            {
                                builder2.Append(word[j]);
                            }
                            subStrings.Add(builder2.ToString());
                        }
                    }
                }
                return subStrings;
            }
        }
    }
}
