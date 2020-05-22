using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A161 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsOneEditDistance(string s, string t)
            {
                if (s.Length > t.Length)
                {
                    var temp = s;
                    s = t;
                    t = temp;
                }
                if (t.Length - s.Length > 1)
                {
                    return false;
                }
                
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != t[i])
                    {
                        if (s.Length == t.Length)
                        {
                            return s.Substring(i + 1).Equals(t.Substring(i + 1));
                        }
                        else
                        {
                            return s.Substring(i).Equals(t.Substring(i + 1));
                        }
                    }
                }
                return s.Length + 1 == t.Length;
            }
        }
    }
}
