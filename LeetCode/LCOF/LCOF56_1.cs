using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF56_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //一个整型数组 nums 里除两个数字之外，其他数字都出现了两次。请写程序找出这两个只出现一次的数字。要求时间复杂度是O(n)，空间复杂度是O(1)。

        //思路解析：
        //利用异或的特性，一个数与自己的异或是0，一个数与0的异或还是他本身

        public int[] SingleNumbers(int[] nums)
        {
            if(nums.Length < 3)
            {
                return nums;
            }
            //对所有数字异或，最终结果就是那两个只出现一次的数的异或
            int temp = 0;
            foreach(var n in nums)
            {
                temp ^= n;
            }
            //找到最低位的1（比一定非得是最低位，随便哪位都行），由于异或是1，这两个数的二进制在这一位上一定不同
            int r = 1;
            while((temp & r) == 0)
            {
                r = r << 1;
            }
            //按照二进制是0还是1对所有的数分组，分组后再异或，得到的就是只出现一次的两个数
            int a = 0;
            int b = 0;
            foreach(var n in nums)
            {
                if((n & r) == 0)
                {
                    a ^= n;
                }
                else
                {
                    b ^= n;
                }
            }
            return new int[] { a, b };
        }
    }
}
