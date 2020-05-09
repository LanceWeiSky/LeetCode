using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0600._80
{
    class A692 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> TopKFrequent(string[] words, int k)
            {
                Dictionary<string, int> map = new Dictionary<string, int>(words.Length);
                foreach (var w in words)
                {
                    if (map.TryGetValue(w, out var count))
                    {
                        map[w] = count + 1;
                    }
                    else
                    {
                        map.Add(w, 1);
                    }
                }
                SortedSet<WordInfo> set = new SortedSet<WordInfo>(new WordComparer());
                foreach (var kp in map)
                {
                    set.Add(new WordInfo { Word = kp.Key, Count = kp.Value });
                    if (set.Count > k)
                    {
                        set.Remove(set.Max);
                    }
                }
                return set.Select(w => w.Word).ToList();
            }

            public class WordInfo
            { 
                public string Word { get; set; }
                public int Count { get; set; }
            }

            public class WordComparer : IComparer<WordInfo>
            {
                public int Compare(WordInfo x, WordInfo y)
                {
                    var ret = y.Count.CompareTo(x.Count);
                    if (ret == 0)
                    {
                        ret = x.Word.CompareTo(y.Word);
                    }
                    return ret;
                }
            }
        }
    }
}
