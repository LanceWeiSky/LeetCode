using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A186 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public void ReverseWords(char[] s)
            {
                Reverse(s, 0, s.Length - 1);
                int start = 0;
                for (int i = 0; i <= s.Length; i++)
                {
                    if (i == s.Length || s[i] == ' ')
                    {
                        Reverse(s, start, i - 1);
                        start = i + 1;
                    }
                }
            }

            private void Reverse(char[] s, int start, int end)
            {
                while (start < end)
                {
                    var temp = s[start];
                    s[start++] = s[end];
                    s[end--] = temp;
                }
            }
        }
    }
}
