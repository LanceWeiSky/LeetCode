using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._00
{
    class A316 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().RemoveDuplicateLetters("bcabc");
        }

        public class Solution
        {
            public string RemoveDuplicateLetters(string s)
            {
                if (s.Length < 2)
                {
                    return s;
                }
                int[] count = new int[26];
                foreach (var c in s)
                {
                    count[c - 'a']++;
                }
                HashSet<char> seen = new HashSet<char>();
                Stack<char> stack = new Stack<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    count[s[i] - 'a']--;
                    if (!seen.Add(s[i]))
                    {
                        continue;
                    }
                    while (stack.Count > 0 && stack.Peek() > s[i] && count[stack.Peek() - 'a'] > 0)
                    {
                        seen.Remove(stack.Pop());
                    }
                    stack.Push(s[i]);
                }
                return new string(stack.ToArray().Reverse().ToArray());
            }
        }
    }
}
