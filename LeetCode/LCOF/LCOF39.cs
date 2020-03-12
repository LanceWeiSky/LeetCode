using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeetCode.Interview.LCOF
{
    class LCOF39 : IQuestion
    {
        public void Run()
        {
            string input = "";
            var nums = JsonSerializer.Deserialize<int[]>(input);
            var ans = MajorityElement(nums);
        }

        //数组中有一个数字出现的次数超过数组长度的一半，请找出这个数字。

        //累加法，如果出现相同的数则count加1，否count减1，count为0时换数重新计数，最后剩下的一定是超过一半长度的数
        public int MajorityElement(int[] nums)
        {
            int target = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (target == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    target = nums[i];
                    count = 1;
                }
            }
            return target;
        }

        //排序后取中间位置的数
        public int MajorityElement_2(int[] nums)
        {
            var temp = nums.ToList();
            temp.Sort();
            return temp[temp.Count / 2];
        }
    }
}
