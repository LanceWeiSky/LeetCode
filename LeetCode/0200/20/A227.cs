using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A227 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int Calculate(string s)
            {
                Stack<int> stack = new Stack<int>();
                int num = 0;
                char sign = '+';
                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (Char.IsDigit(c))
                    {
                        num = num * 10 + (c - '0');
                    }
                    if (c != ' ' && !Char.IsDigit(c) || i == s.Length - 1)
                    {
                        if (sign == '+')
                        {
                            stack.Push(num);
                        }
                        else if (sign == '-')
                        {
                            stack.Push(-num);
                        }
                        else if (sign == '*')
                        {
                            stack.Push(stack.Pop() * num);
                        }
                        else if (sign == '/')
                        {
                            stack.Push(stack.Pop() / num);
                        }
                        num = 0;
                        sign = c;
                    }
                }
                int result = 0;
                while (stack.Count > 0)
                {
                    result += stack.Pop();
                }
                return result;
            }
        }
    }
}
