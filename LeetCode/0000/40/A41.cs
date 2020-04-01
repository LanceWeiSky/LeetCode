using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0000._40
{
    class A41 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个未排序的整数数组，请你找出其中没有出现的最小的正整数。



        //示例 1:

        //输入: [1,2,0]
        //        输出: 3


        //示例 2:

        //输入: [3,4,-1,1]
        //        输出: 2


        //示例 3:

        //输入: [7,8,9,11,12]
        //        输出: 1




        //提示：

        //你的算法的时间复杂度应为O(n)，并且只能使用常数级别的额外空间。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/first-missing-positive
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int FirstMissingPositive(int[] nums)
        {
            if (!nums.Contains(1))
            {
                return 1;
            }
            if(nums.Length == 1)
            {
                return 2;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 1 || nums[i] > nums.Length)
                {
                    nums[i] = 1;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]);
                if (index == nums.Length)
                {
                    nums[0] = -Math.Abs(nums[0]);
                }
                else
                {
                    nums[index] = -Math.Abs(nums[index]);
                }
            }
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    return i;
                }
            }
            if (nums[0] > 0)
            {
                return nums.Length;
            }
            return nums.Length + 1;
        }
    }
}
