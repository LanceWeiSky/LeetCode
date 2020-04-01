using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A34 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。

        //你的算法时间复杂度必须是 O(log n) 级别。

        //如果数组中不存在目标值，返回[-1, -1]。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int[] SearchRange(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            int index = -1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    index = mid;
                    break;
                }
                if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            if (index == -1)
            {
                return new int[] { -1, -1 };
            }
            l = index;
            r = index;
            while (l >= 0 && nums[l] == target)
            {
                l--;
            }
            while (r < nums.Length && nums[r] == target)
            {
                r++;
            }
            return new int[] { l + 1, r - 1 };
        }
    }
}
