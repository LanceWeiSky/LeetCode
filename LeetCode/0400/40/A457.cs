using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._40
{
    class A457 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CircularArrayLoop(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        continue;
                    }

                    int slow = i;
                    int fast = GetNext(nums, i);
                    while (nums[i] * nums[fast] > 0 && nums[i] * nums[GetNext(nums, fast)] > 0)
                    {
                        slow = GetNext(nums, slow);
                        fast = GetNext(nums, GetNext(nums, fast));
                        if (slow == fast)
                        {
                            if (slow == GetNext(nums, slow))
                            {
                                break;
                            }
                            return true;
                        }
                    }

                    slow = GetNext(nums, i);
                    while (nums[i] * nums[slow] > 0)
                    {
                        var temp = slow;
                        slow = GetNext(nums, slow);
                        nums[temp] = 0;
                    }
                    nums[i] = 0;
                }
                return false;
            }

            private int GetNext(int[] nums, int i)
            {
                i = (i + nums[i]) % nums.Length;
                if(i < 0)
                {
                    i += nums.Length;
                }
                return i;
            }
        }
    }
}
