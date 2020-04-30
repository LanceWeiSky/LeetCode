using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A344 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public void ReverseString(char[] s)
            {
                for (int i = 0; i < s.Length / 2; i++)
                {
                    var temp = s[i];
                    s[i] = s[s.Length - i - 1];
                    s[s.Length - i - 1] = temp;
                }
            }
        }
    }
}
