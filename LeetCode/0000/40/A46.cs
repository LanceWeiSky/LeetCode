using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A46 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个 没有重复 数字的序列，返回其所有可能的全排列。

        public IList<IList<int>> Permute(int[] nums)
        {
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
            for (int i = index; i < nums.Length; i++)
            {
                Swap(nums, index, i);
                PermuteInternal(nums, ans, index + 1);
                Swap(nums, index, i);
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
