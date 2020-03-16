using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0000._00
{
    class A16 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。

        //例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.

        //与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2).

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/3sum-closest
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int ThreeSumClosest(int[] nums, int target)
        {
            if(nums.Length < 4)
            {
                return nums.Sum();
            }
            Array.Sort(nums);//排序降低复杂度
            int sum = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int n = nums[i];
                int l = i + 1;
                int r = nums.Length - 1;
                if (i == 0)
                {
                    sum = n + nums[l] + nums[r];
                }
                while (l < r)//双指针遍历
                {
                    var temp = n + nums[l] + nums[r];
                    if(temp == target)
                    {
                        return temp;
                    }
                    if(Math.Abs(temp - target) < Math.Abs(sum - target))
                    {
                        sum = temp;
                    }
                    if(temp < target)//有序数组，值比target小，则移动左指针，否则移动又指针
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
            return sum;
        }
    }
}
