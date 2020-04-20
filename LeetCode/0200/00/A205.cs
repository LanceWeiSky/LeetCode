using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCode._0200._00
{
    class A205 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsIsomorphic(string s, string t)
        {
            int n = s.Length;
            if (n == 0)
            {
                return true;
            }
            return IsIsomorphic(s, t, n) && IsIsomorphic(t, s, n);
        }

        private bool IsIsomorphic(string s, string t, int n)
        {
            Dictionary<char, char> map = new Dictionary<char, char>(n);
            for (int i = 0; i < n; i++)
            { 
                if (map.TryGetValue(s[i], out var c))
                {
                    if (c != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    map[s[i]] = t[i];
                }
            }
            return true;
        }
    }
}
