using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A162 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //峰值元素是指其值大于左右相邻值的元素。

        //给定一个输入数组 nums，其中 nums[i] ≠ nums[i + 1]，找到峰值元素并返回其索引。

        //数组可能包含多个峰值，在这种情况下，返回任何一个峰值所在位置即可。

        //你可以假设 nums[-1] = nums[n] = -∞。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/find-peak-element
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int FindPeakElement(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            int l = 0;
            int r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}
