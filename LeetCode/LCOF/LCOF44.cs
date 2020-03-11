using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF44 : IQuestion
    {
        public void Run()
        {
            var ans = FindNthDigit(25);
        }

        //数字以0123456789101112131415…的格式序列化到一个字符序列中。在这个序列中，第5位（从下标0开始计数）是5，第13位是1，第19位是4，等等。

        //请写一个函数，求任意第n位对应的数字。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/shu-zi-xu-lie-zhong-mou-yi-wei-de-shu-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //单位数0~9占1*10位
        //双位数10~99占2*90位
        //三位数100~999占3*900位
        //...
        //以25为例，首先判断这是一个几位数，25在1*10 ~ 1*10 + 2*90之间，所以是一个两位数。
        //然后计算他是第几个两位数，由于两位数从10开始，所以25-10=15，他是两位数开始的第15位。
        //由于是2位数，一个数字占2位，所以需要除以2，15/2=7，他是第7个（从0开始计数）两位数，第0个两位数是10，所以这个两位数是10+7=17
        //再计算他是两位数的第几位，15%2=1，所以他是两位数的第1位（从左到右，从0开始计数），17的第一位是7

        public int FindNthDigit(int n)
        {
            if (n < 9)
            {
                return n;
            }
            int startNumber = 1;
            int bit = 1;
            long length = 10;
            long prevLength = 1;
            long bitLength = 9;
            while (n >= length)
            {
                bit++;
                bitLength *= 10;
                startNumber *= 10;
                prevLength = length;
                length += bit * bitLength;
            }
            var offset = n - (int)prevLength;
            var bitIndex = offset % bit;
            var num = offset / bit + startNumber;
            for (int i = bit - bitIndex - 1; i > 0; i--)
            {
                num /= 10;
            }
            return num % 10;
        }
    }
}
