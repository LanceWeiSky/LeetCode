using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A557 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string ReverseWords(string s)
            {
                StringBuilder builder = new StringBuilder(s.Length);
                Stack<char> stack = new Stack<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        while(stack.Count > 0)
                        {
                            builder.Append(stack.Pop());
                        }
                        builder.Append(s[i]);
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
                while (stack.Count > 0)
                {
                    builder.Append(stack.Pop());
                }
                return builder.ToString();
            }
        }
    }
}
