using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A214 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public string ShortestPalindrome(string s)
        {
            int length = ManacherLength(s);
            StringBuilder builder = new StringBuilder();
            for (int i = s.Length - 1; i >= length; i--)
            {
                builder.Append(s[i]);
            }
            builder.Append(s);
            return builder.ToString();
        }

        private int ManacherLength(string s)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("^#");
            foreach (var c in s)
            {
                builder.Append(c);
                builder.Append('#');
            }
            builder.Append('$');
            string s2 = builder.ToString();
            int[] p = new int[s2.Length];
            int max = 0;
            int id = 0;
            int length = 0;
            for (int i = 1; i < s2.Length - 1; i++)
            {
                if (i < max)
                {
                    p[i] = Math.Min(max - i, p[2 * id - i]);
                }
                else
                {
                    p[i] = 1;
                }
                while (s2[i + p[i]] == s2[i - p[i]])
                {
                    p[i]++;
                }
                if (i + p[i] > max)
                {
                    max = i + p[i];
                    id = i;
                }
                if ((i - p[i]) / 2 == 0 && p[i] > length)
                {
                    length = p[i];
                }
            }
            return length - 1;
        }
    }
}
