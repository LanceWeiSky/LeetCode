using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._40
{
    class A1249 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string MinRemoveToMakeValid(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return s;
                }
                Stack<int> stack = new Stack<int>();
                bool[] invalid = new bool[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == '(')
                    {
                        stack.Push(i);
                        invalid[i] = true;
                    }
                    else if (c == ')')
                    {
                        if (stack.Count == 0)
                        {
                            invalid[i] = true;
                        }
                        else
                        {
                            invalid[stack.Pop()] = false;
                        }
                    }
                }
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                { 
                    if(!invalid[i])
                    {
                        builder.Append(s[i]);
                    }
                }
                return builder.ToString();
            }
        }
    }
}
