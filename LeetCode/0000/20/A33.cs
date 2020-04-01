using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A33 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。

        //(例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。

        //搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。

        //你可以假设数组中不存在重复的元素。

        //你的算法时间复杂度必须是 O(log n) 级别。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while(l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] >= nums[l])
                {
                    if (nums[mid] > target && nums[l] <= target)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && nums[r] >= target)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}
