using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._20
{
    class A224 : IQuestion
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
                int result = 0;
                int num = 0;
                int sign = 1;
                foreach (var c in s)
                {
                    if (c == '(')
                    {
                        stack.Push(result);
                        stack.Push(sign);
                        result = 0;
                        sign = 1;
                        num = 0;
                    }
                    else if (c == ')')
                    {
                        result += sign * num;
                        result *= stack.Pop();
                        result += stack.Pop();
                        sign = 1;
                        num = 0;
                    }
                    else if (c == '+')
                    {
                        result += sign * num;
                        sign = 1;
                        num = 0;
                    }
                    else if (c == '-')
                    {
                        result += sign * num;
                        sign = -1;
                        num = 0;
                    }
                    else if (Char.IsDigit(c))
                    {
                        num = num * 10 + (c - '0');
                    }
                }
                return result + sign * num;
            }

        }
    }
}
