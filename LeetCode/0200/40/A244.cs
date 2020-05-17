using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0200._40
{
    class A244 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class WordDistance
        {

            private readonly Dictionary<string, List<int>> _map;

            public WordDistance(string[] words)
            {
                _map = new Dictionary<string, List<int>>(words.Length);
                for (int i = 0; i < words.Length; i++)
                {
                    if (!_map.TryGetValue(words[i], out var list))
                    {
                        list = new List<int>();
                        _map.Add(words[i], list);
                    }
                    list.Add(i);
                }
            }

            public int Shortest(string word1, string word2)
            {
                if (!_map.TryGetValue(word1, out var indexes1) || !_map.TryGetValue(word2, out var indexes2))
                {
                    return -1;
                }
                int i = 0;
                int j = 0;
                int ret = int.MaxValue;
                while (i < indexes1.Count && j < indexes2.Count)
                {
                    if (indexes1[i] > indexes2[j])
                    {
                        ret = Math.Min(indexes1[i] - indexes2[j], ret);
                        j++;
                    }
                    else
                    {
                        ret = Math.Min(indexes2[j] - indexes1[i], ret);
                        i++;
                    }
                }
                if (i == indexes1.Count)
                {
                    for (int k = j; k < indexes2.Count; k++)
                    {
                        ret = Math.Min(ret, Math.Abs(indexes2[k] - indexes1.Last()));
                    }
                }
                else if (j == indexes2.Count)
                {
                    for (int k = i; k < indexes1.Count; k++)
                    {
                        ret = Math.Min(ret, Math.Abs(indexes1[k] - indexes2.Last()));
                    }
                }
                return ret;
            }
        }
    }
}
