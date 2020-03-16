using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A9 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

        public bool IsPalindrome(int x)
        {
            if (x == 0)
            {
                return true;
            }
            if (x < 0 || x % 10 == 0)
            {
                return false;
            }
            //判断后一半数字翻转是否等于前一半数字
            int num = 0;
            while(x > num)
            {
                num = num * 10 + x % 10;
                x /= 10;
            }
            return x == num || x == num / 10;//奇数位情况翻转数字num会比x多一位，消掉最后一位
        }

        public bool IsPalindrome_2(int x)
        {
            if(x < 0)
            {
                return false;
            }
            int[] nums = new int[10];
            int count = 0;
            while(x != 0)
            {
                nums[count++] = x % 10;
                x /= 10;
            }
            int half = count / 2;
            for(int i = 0; i < half; i++)
            {
                if(nums[i] != nums[count - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
