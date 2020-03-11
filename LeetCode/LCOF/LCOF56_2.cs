using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF56_2 : IQuestion
    {
        public void Run()
        {
            int[] nums = { 3, 4, 3, 3 };
            var ans = SingleNumber(nums);
        }

        //在一个数组 nums 中除一个数字只出现一次之外，其他数字都出现了三次。请找出那个只出现一次的数字。

        //思路解析：
        //对二进制的各个位做与操作，并计数，相同数字同一位一定相同，所以有两种可能。
        //1.计数后可以被3整除，只出现一次的数字在这一位一定是0。
        //2.计数后不能被3整除，只出现一次的数字在这一位一定是1.
        //得到的32位01值就是只出现一次的数字的二进制形式。

        public int SingleNumber(int[] nums)
        {
            int ans = 0;
            for(int i = 0; i < 32; i++)
            {
                int bit = 1 << i;
                int count = 0;
                foreach(var n in nums)
                {
                    if((n & bit) != 0)
                    {
                        count++;
                    }
                }
                if(count % 3 != 0)
                {
                    ans |= bit;
                }
            }
            return ans;
        }
    }
}
