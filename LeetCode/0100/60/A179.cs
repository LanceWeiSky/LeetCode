using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0100._60
{
    class A179 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public string LargestNumber(int[] nums)
        {
            List<string> numStrs = nums.Select(n => n.ToString()).ToList();
            numStrs.Sort((x, y) => (y + x).CompareTo(x + y));
            string ans = string.Concat(numStrs).TrimStart('0');
            if (ans == "")
            {
                return "0";
            }
            return ans;
        }

    }
}
