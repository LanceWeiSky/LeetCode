using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A167 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;
            while (l < r)
            {
                if (numbers[l] + numbers[r] == target)
                {
                    return new int[] { l + 1, r + 1 };
                }
                else if (numbers[l] + numbers[r] > target)
                {
                    r--;
                }
                else
                {
                    l++;
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
