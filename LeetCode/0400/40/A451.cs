using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A451 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string FrequencySort(string s)
            {
                Dictionary<char, int> counter = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    if (counter.TryGetValue(c, out var count))
                    {
                        counter[c] = count + 1;
                    }
                    else
                    {
                        counter.Add(c, 1);
                    }
                }
                List<CharInfo> cs = new List<CharInfo>(counter.Count);
                foreach (var kp in counter)
                {
                    cs.Add(new CharInfo { Char = kp.Key, Count = kp.Value });
                }
                cs.Sort((x, y) => y.Count.CompareTo(x.Count));
                StringBuilder builder = new StringBuilder();
                foreach (var c in cs)
                {
                    builder.Append(c.Char, c.Count);
                }
                return builder.ToString();
            }

            private class CharInfo
            {
                public char Char { get; set; }
                public int Count { get; set; }
            }
        }
    }
}
