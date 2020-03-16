using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A18 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。

        //注意：

        //答案中不可以包含重复的四元组。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/4sum
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //参考三数和
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length < 4)
            {
                return new List<IList<int>>();
            }
            Array.Sort(nums);
            List<IList<int>> ans = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 3;)
            {
                for (int j = i + 1; j < nums.Length - 2;)
                {
                    int l = j + 1;
                    int r = nums.Length - 1;
                    while (l < r)
                    {
                        var sum = nums[i] + nums[j] + nums[l] + nums[r];
                        if (sum == target)
                        {
                            ans.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                        }
                        if (sum < target)
                        {
                            while (l < r && nums[l] == nums[++l]) { }
                        }
                        else
                        {
                            while (l < r && nums[r] == nums[--r]) { }
                        }
                    }
                    while (j < nums.Length - 2 && nums[j] == nums[++j]) { }
                }
                while (i < nums.Length - 3 && nums[i] == nums[++i]) { }
            }
            return ans;
        }
    }
}
