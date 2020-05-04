using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A443 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int Compress(char[] chars)
            {
                char prev = chars[0];
                int count = 1;
                int index = 0;
                for (int i = 1; i < chars.Length; i++)
                {
                    if (chars[i] == prev)
                    {
                        count++;
                    }
                    else
                    {
                        chars[index++] = prev;
                        if (count > 1)
                        {
                            foreach (var c in count.ToString())
                            {
                                chars[index++] = c;
                            }
                        }
                        prev = chars[i];
                        count = 1;
                    }
                }
                chars[index++] = prev;
                if (count > 1)
                {
                    foreach (var c in count.ToString())
                    {
                        chars[index++] = c;
                    }
                }
                return index;
            }
        }
    }
}
