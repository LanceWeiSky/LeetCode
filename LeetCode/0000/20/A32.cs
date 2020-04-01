using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A32 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。

        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            int ans = 0;

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        ans = Math.Max(ans, i - stack.Peek());
                    }
                }
            }
            return ans;
        }
    }
}
