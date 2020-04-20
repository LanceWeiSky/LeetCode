using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._40
{
    class A242 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    return false;
                }
                Dictionary<char, int> charCount = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    charCount.TryGetValue(c, out var count);
                    charCount[c] = count + 1;
                }

                foreach (var c in t)
                {
                    if (charCount.TryGetValue(c, out var count))
                    {
                        if (count == 0)
                        {
                            return false;
                        }
                        charCount[c] = count - 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
