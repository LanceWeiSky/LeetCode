using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A384 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private readonly int[] _original;
            private readonly Random _rnd = new Random();

            public Solution(int[] nums)
            {
                _original = nums;
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                return _original;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                int[] nums = new int[_original.Length];
                Array.Copy(_original, nums, nums.Length);
                for (int i = 0; i < nums.Length; i++)
                {
                    var j = _rnd.Next(i, nums.Length);
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
                return nums;
            }
        }
    }
}
