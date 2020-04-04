using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A81 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。

        //(例如，数组[0, 0, 1, 2, 2, 5, 6] 可能变为[2, 5, 6, 0, 0, 1, 2] )。

        //编写一个函数来判断给定的目标值是否存在于数组中。若存在返回 true，否则返回 false。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[l] == nums[mid])
                {
                    l++;
                }
                else if (nums[l] < nums[mid])
                {
                    if (target < nums[mid] && target > nums[l])
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
                    if (target < nums[r] && target > nums[mid])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
            }
            return false;
        }
    }
}
