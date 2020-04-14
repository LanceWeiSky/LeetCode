using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A171 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int TitleToNumber(string s)
        {
            int ans = 0;
            foreach (var c in s)
            {
                ans = ans * 26 + c - 'A' + 1;
            }
            return ans;
        }
    }
}
