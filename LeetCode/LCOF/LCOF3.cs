using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{

    class LCOF3 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //在一个长度为 n 的数组 nums 里的所有数字都在 0～n-1 的范围内。
        //数组中某些数字是重复的，但不知道有几个数字重复了，也不知道每个数字重复了几次。请找出数组中任意一个重复的数字。
        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/shu-zu-zhong-zhong-fu-de-shu-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //1.利用HashSet存储已存在的数字，遍历数组，如果存在则返回。
        //2.由于所有数字都在0~n-1范围内，可以定义一个长度为n的数组，数组的索引代表数字，值代表数字出现的次数.
        public int FindRepeatNumber(int[] nums)
        {
            int[] temp = new int[nums.Length];
            foreach (var num in nums)
            {
                if (temp[num] == 1)
                {
                    return num;
                }
                temp[num] = 1;
            }
            return 0;
        }
    }
}
