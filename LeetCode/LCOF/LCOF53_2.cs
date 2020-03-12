using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF53_2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //一个长度为n-1的递增排序数组中的所有数字都是唯一的，并且每个数字都在范围0～n-1之内。
        //在范围0～n-1内的n个数字中有且只有一个数字不在该数组中，请找出这个数字。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/que-shi-de-shu-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MissingNumber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == mid)//索引与数值相等代表左侧没有丢失数字，向右侧寻找，否则代表左侧有丢失数字，向左侧寻找
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (nums[left] == left)
            {
                return left + 1;
            }
            return left;
        }
    }
}
