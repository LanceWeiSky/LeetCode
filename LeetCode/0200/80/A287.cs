using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A287 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().FindDuplicate(new int[] { 1, 2, 3, 4, 2, 5 });
        }

        public class Solution
        {
            public int FindDuplicate(int[] nums)
            {
                int slow = nums[0];
                int fast = nums[0];
                do
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                } while (slow != fast);

                slow = nums[0];
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[fast];
                }
                return slow;
            }
        }
    }
}
