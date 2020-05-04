using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0200._60
{
    class A269 : IQuestion
    {
        public void Run()
        {
            new Solution().AlienOrder(new string[] { "wrt", "wrf", "er", "ett", "rftt" });
        }

        public class Solution
        {
            public string AlienOrder(string[] words)
            {
                Dictionary<char, HashSet<char>> map = new Dictionary<char, HashSet<char>>();
                for (int i = 1; i < words.Length; i++)
                {
                    int j = 0;
                    int length = Math.Min(words[i - 1].Length, words[i].Length);
                    while (j < length && words[i - 1][j] == words[i][j])
                    {
                        j++;
                    }
                    if (j >= length)
                    {
                        if (words[i - 1].Length > length)
                        {
                            return string.Empty;
                        }
                        continue;
                    }
                    if (!map.TryGetValue(words[i - 1][j], out var set))
                    {
                        set = new HashSet<char>();
                        map.Add(words[i - 1][j], set);
                    }
                    set.Add(words[i][j]);
                }

                int[] indegree = new int[26];
                Array.Fill(indegree, -1);
                foreach (var w in words)
                {
                    foreach (var c in w)
                    {
                        indegree[c - 'a'] = 0;
                    }
                }
                foreach (var m in map)
                {
                    foreach (var c in m.Value)
                    {
                        indegree[c - 'a']++;
                    }
                }
                var count = indegree.Count(d => d >= 0);
                StringBuilder builder = new StringBuilder();
                Queue<char> queue = new Queue<char>();
                for (int i = 0; i < indegree.Length; i++)
                {
                    if (indegree[i] == 0)
                    {
                        queue.Enqueue((char)(i + 'a'));
                    }
                }
                while (queue.Count > 0)
                {
                    var ch = queue.Dequeue();
                    builder.Append(ch);
                    if (map.TryGetValue(ch, out var set))
                    {
                        foreach (var next in set)
                        {
                            indegree[next - 'a']--;
                            if (indegree[next - 'a'] == 0)
                            {
                                queue.Enqueue(next);
                            }
                        }
                    }
                }
                if (builder.Length != count)
                {
                    return string.Empty;
                }
                return builder.ToString();
            }
        }
    }
}
