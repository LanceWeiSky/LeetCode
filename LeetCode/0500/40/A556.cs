using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._40
{
    class A556 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NextGreaterElement(int n)
            {
                List<int> nums = new List<int>();
                while(n > 0)
                {
                    nums.Add(n % 10);
                    n /= 10;
                }
                int index = 1;
                while (index < nums.Count)
                {
                    if (nums[index] < nums[index - 1])
                    {
                        break;
                    }
                    index++;
                }
                if(index == nums.Count)
                {
                    return -1;
                }
                var j = nums.BinarySearch(0, index, nums[index], Comparer<int>.Default);
                if (j < 0)
                {
                    j = ~j;
                }
                else
                {
                    while (nums[j] == nums[index])
                    {
                        j++;
                    }
                }
                Swap(nums, j, index);
                int left = 0, right = index - 1;
                while (left < right)
                {
                    Swap(nums, left++, right--);
                }
                long ans = 0;
                for(int i = nums.Count - 1; i >= 0; i--)
                {
                    ans = ans * 10 + nums[i];
                    if (ans > int.MaxValue)
                    {
                        return -1;
                    }
                }
                return (int)ans;
            }

            private void Swap(List<int> nums, int i, int j)
            {
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
