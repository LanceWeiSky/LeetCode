using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A168 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public string ConvertToTitle(int n)
        {
            StringBuilder builder = new StringBuilder();
            while (n > 0)
            {
                n--;
                var m = n % 26;
                builder.Insert(0, (char)('A' + m));
                n = n / 26;
            }
            return builder.ToString();
        }
    }
}
