using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._40
{
    class A647 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CountSubstrings(string s)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("$#");
                foreach (var c in s)
                {
                    builder.Append(c);
                    builder.Append('#');
                }
                builder.Append('^');
                string newStr = builder.ToString();
                int[] p = new int[newStr.Length];
                int ip = 0;
                int max = 0;
                int count = 0;
                for (int i = 1; i < p.Length - 1; i++)
                {
                    if (i < max)
                    {
                        p[i] = Math.Min(max - i, p[ip * 2 - i]);
                    }
                    while (newStr[i + p[i]] == newStr[i - p[i]])
                    {
                        p[i]++;
                    }
                    if (i + p[i] > max)
                    {
                        max = i + p[i];
                        ip = i;
                    }
                    count += p[i] / 2;
                }
                return count;
            }

        }
    }
}
