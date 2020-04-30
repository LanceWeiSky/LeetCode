using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode._0400._00
{
    class A402 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string RemoveKdigits(string num, int k)
            {
                if (num.Length == k)
                {
                    return "0";
                }
                if (k == 0)
                {
                    return num;
                }
                int removeCount = 0;
                char[] cs = new char[num.Length];
                int index = 0;
                for (int i = 0; i < num.Length; i++)
                {
                    while (removeCount < k && index > 0 && cs[index - 1] > num[i])
                    {
                        index--;
                        removeCount++;
                    }
                    cs[index++] = num[i];
                }
                string ans = new string(cs.Take(num.Length - k).ToArray()).TrimStart('0');
                if (ans.Length == 0)
                {
                    ans = "0";
                }
                return ans;
            }
        }
    }
}
