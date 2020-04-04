using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A80 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个排序数组，你需要在原地删除重复出现的元素，使得每个元素最多出现两次，返回移除后数组的新长度。

        //不要使用额外的数组空间，你必须在原地修改输入数组并在使用 O(1) 额外空间的条件下完成。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int index = 1;
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count < 3)
                {
                    nums[index++] = nums[i];
                }
            }
            return index;
        }
    }
}
