using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A415 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string AddStrings(string num1, string num2)
            {
                int i1 = num1.Length - 1;
                int i2 = num2.Length - 1;
                int carry = 0;
                Stack<char> stack = new Stack<char>();
                while (i1 >= 0 || i2 >= 0)
                {
                    int n1 = 0;
                    int n2 = 0;
                    if (i1 >= 0)
                    {
                        n1 = num1[i1--] - '0';
                    }
                    if (i2 >= 0)
                    {
                        n2 = num2[i2--] - '0';
                    }
                    var s = n1 + n2 + carry;
                    carry = s / 10;
                    s = s % 10;
                    stack.Push((char)(s + '0'));
                }
                if (carry > 0)
                {
                    stack.Push((char)(carry + '0'));
                }
                StringBuilder builder = new StringBuilder();
                while (stack.Count > 0)
                {
                    builder.Append(stack.Pop());
                }
                return builder.ToString();
            }
        }
    }
}
