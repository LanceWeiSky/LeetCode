using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A290 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool WordPattern(string pattern, string str)
            {
                var words = str.Split(' ');
                if (words.Length != pattern.Length)
                {
                    return false;
                }
                HashSet<char> seen = new HashSet<char>();
                Dictionary<string, char> map = new Dictionary<string, char>();
                for (int i = 0; i < words.Length; i++)
                {
                    if (map.TryGetValue(words[i], out var c))
                    {
                        if (c != pattern[i])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!seen.Add(pattern[i]))
                        {
                            return false;
                        }
                        map[words[i]] = pattern[i];
                    }
                }
                return true;
            }
        }
    }
}
