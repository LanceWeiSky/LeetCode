using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A386 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> LexicalOrder(int n)
            {
                List<int> ans = new List<int>();
                if (n < 10)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        ans.Add(i);
                    }
                    return ans;
                }

                Stack<int> stack = new Stack<int>();
                for (int i = 9; i > 0; i--)
                {
                    stack.Push(i);
                }
                while (stack.Count > 0)
                {
                    var v = stack.Pop();
                    ans.Add(v);
                    v *= 10;
                    if (v > n)
                    {
                        continue;
                    }
                    var m = n - v;
                    if(m > 9)
                    {
                        m = 9;
                    }
                    for (int i = m; i >= 0; i--)
                    {
                        stack.Push(v + i);
                    }
                }
                return ans;
            }
        }
    }
}
