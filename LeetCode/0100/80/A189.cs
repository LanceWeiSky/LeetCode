using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._80
{
    class A189 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
            {
                return;
            }
            k = k % nums.Length;
            if (k == 0)
            {
                return;
            }
            int count = 0;
            for (int i = 0; count < nums.Length; i++)
            {
                var start = i;
                var current = i;
                var prev = nums[i];
                do
                {
                    current = (current + k) % nums.Length;
                    var temp = nums[current];
                    nums[current] = prev;
                    prev = temp;
                    count++;
                } while (start != current);
            }
        }
    }
}
