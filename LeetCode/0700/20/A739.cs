using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0700._20
{
    class A739 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] DailyTemperatures(int[] T)
            {
                int[] ans = new int[T.Length];
                Stack<int> stack = new Stack<int>();
                for (int i = T.Length - 1; i >= 0; i--)
                {
                    while (stack.Count > 0 && T[i] >= T[stack.Peek()])
                    {
                        stack.Pop();
                    }
                    if (stack.Count > 0)
                    {
                        ans[i] = stack.Peek() - i;
                    }
                    stack.Push(i);
                }
                return ans;
            }
        }
    }
}
