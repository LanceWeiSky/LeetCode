using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A75 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。

        //此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。

        //注意:
        //不能使用代码库中的排序函数来解决这道题。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/sort-colors
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public void SortColors(int[] nums)
        {
            int p0 = 0;
            int cur = 0;
            int p2 = nums.Length - 1;
            while (cur <= p2)
            {
                if (nums[cur] == 0)
                {
                    nums[cur++] = nums[p0];
                    nums[p0++] = 0;
                }
                else if (nums[cur] == 2)
                {
                    nums[cur] = nums[p2];
                    nums[p2--] = 2;
                }
                else
                {
                    cur++;
                }
            }
        }
    }
}
