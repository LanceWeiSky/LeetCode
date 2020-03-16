using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A15 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有满足条件且不重复的三元组。

        //注意：答案中不可以包含重复的三元组。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/3sum
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return ans;
            }
            Array.Sort(nums);//排序，降低复杂度
            if (nums[nums.Length - 1] < 0)
            {
                return ans;
            }
            for (int i = 0; i < nums.Length - 2;)
            {
                var v = nums[i];
                if (v > 0)//最小数大于0，退出循环
                {
                    break;
                }
                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    if (nums[r] < 0)//最大数<0，退出循环
                    {
                        break;
                    }
                    var sum = v + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        ans.Add(new List<int> { v, nums[l], nums[r] });
                    }
                    if (sum < 0)
                    {
                        while (l < r && nums[l] == nums[++l]) { }//跳过相同数
                    }
                    else
                    {
                        while (l < r && nums[r] == nums[--r]) { }//跳过相同数
                    }
                }
                while (i < nums.Length - 1 && nums[i] == nums[++i]) { }//跳过相同数
            }
            return ans;
        }
    }
}
