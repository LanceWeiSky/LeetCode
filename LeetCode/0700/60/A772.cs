using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._60
{
    class A772 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int Calculate(string s)
            {
                int index = 0;
                return Calc(s, ref index);
            }

            private int Calc(string s, ref int index)
            {
                Stack<int> stack = new Stack<int>();
                int num = 0;
                char op = '+';
                while (index < s.Length)
                {
                    var c = s[index++];
                    if (Char.IsDigit(c))
                    {
                        num = num * 10 + (c - '0');
                    }
                    else if (c == '(')
                    {
                        num = Calc(s, ref index);
                    }
                    
                    
                    if(!Char.IsDigit(c) && c != '(' && c != ' ' || index == s.Length)
                    {
                        if (op == '+')
                        {
                            stack.Push(num);
                        }
                        else if (op == '-')
                        {
                            stack.Push(-num);
                        }
                        else if (op == '*')
                        {
                            stack.Push(num * stack.Pop());
                        }
                        else if (op == '/')
                        {
                            stack.Push(stack.Pop() / num);
                        }
                        num = 0;
                        op = c;
                    }

                    if (c == ')')
                    {
                        break;
                    }
                }
                int ans = 0;
                while(stack.Count > 0)
                {
                    ans += stack.Pop();
                }
                return ans;
            }
        }
    }
}
