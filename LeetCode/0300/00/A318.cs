using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A318 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxProduct(string[] words)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                foreach (var word in words)
                {
                    int bitMask = 0;
                    foreach (var c in word)
                    {
                        bitMask |= 1 << (c - 'a');
                    }
                    map.TryGetValue(bitMask, out var length);
                    map[bitMask] = Math.Max(length, word.Length);
                }
                int max = 0;
                foreach (var w1 in map)
                {
                    foreach (var w2 in map)
                    {
                        if ((w1.Key & w2.Key) == 0)
                        {
                            max = Math.Max(max, w1.Value * w2.Value);
                        }
                    }
                }
                return max;
            }
        }
    }
}
