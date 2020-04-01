using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A47 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个可包含重复数字的序列，返回所有不重复的全排列。

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ans = new List<IList<int>>();
            PermuteInternal(nums, ans, 0);
            return ans;
        }

        private void PermuteInternal(int[] nums, List<IList<int>> ans, int index)
        {
            if (index == nums.Length)
            {
                ans.Add(new List<int>(nums));
                return;
            }
            HashSet<int> temp = new HashSet<int>(nums.Length);
            for (int i = index; i < nums.Length; i++)
            {
                if (temp.Add(nums[i]))
                {
                    Swap(nums, index, i);
                    PermuteInternal(nums, ans, index + 1);
                    Swap(nums, index, i);
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
