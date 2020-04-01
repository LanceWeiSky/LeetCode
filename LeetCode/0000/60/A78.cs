using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A78 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
        //说明：解集不能包含重复的子集。

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            for (int i = 0; i <= nums.Length; i++)
            {
                Combine(ans, nums, i);
            }
            return ans;
        }

        private void Combine(List<IList<int>> ans, int[] nums, int k)
        {
            int[] temp = new int[k];
            Combine(ans, nums, 0, nums.Length - k, 0, temp);
        }

        private void Combine(List<IList<int>> ans, int[] nums, int startNum, int endNum, int index, int[] temp)
        {
            if (index == temp.Length)
            {
                ans.Add(new List<int>(temp));
                return;
            }
            for (int i = startNum; i <= endNum; i++)
            {
                temp[index] = nums[i];
                Combine(ans, nums, i + 1, endNum + 1, index + 1, temp);
            }
        }
    }
}
