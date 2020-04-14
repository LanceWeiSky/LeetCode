using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A128 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个未排序的整数数组，找出最长连续序列的长度。
        //要求算法的时间复杂度为 O(n)。

        public int LongestConsecutive(int[] nums)
        {
            int ans = 0;
            HashSet<int> set = new HashSet<int>(nums);
            foreach (var num in set)
            {
                if (set.Contains(num - 1))
                {
                    continue;
                }

                var currentNum = num + 1;
                int length = 1;
                while (set.Contains(currentNum++))
                {
                    length++;
                }

                ans = Math.Max(ans, length);
            }
            return ans;
        }
    }
}
