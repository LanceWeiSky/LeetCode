using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A405 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string ToHex(int num)
            {
                char[] map = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                char[] cs = new char[8];
                int mask = 15;
                for (int i = 7; i >= 0; i--)
                {
                    cs[i] = map[num & mask];
                    num >>= 4;
                }
                var s = new string(cs).TrimStart('0');
                if(s.Length == 0)
                {
                    s = "0";
                }
                return s;
            }
        }
    }
}
