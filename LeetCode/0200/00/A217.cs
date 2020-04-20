using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A217 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var n in nums)
            {
                if (!set.Add(n))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
