using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF43 : IQuestion
    {
        public void Run()
        {
            var ans = CountDigitOne(12);
        }

        //输入一个整数 n ，求1～n这n个整数的十进制表示中1出现的次数。

        //例如，输入12，1～12这些整数中包含1 的数字有1、10、11和12，1一共出现了5次。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/1nzheng-shu-zhong-1chu-xian-de-ci-shu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int CountDigitOne(int n)
        {
            int count = 0;
            int bitCount = 0;
            int m = 1;//位数，个位1，十位10，百位100...
            var temp = n;
            while (temp > 0)
            {
                var r = temp % 10;
                temp /= 10;
                count += bitCount * r;//比如369，出现1的次数为3次0~99出现1的次数（000~099，100~199,200~299），加上69出现1的次数（在低位计算过）
                if (r == 1)//比如：169，百位是1，额外出现1的次数是170次，100~169
                {
                    count += n % m + 1;
                }
                else if (r > 1)//比如369，百位是3，额外出现1的次数为百位是1的100次，100~199
                {
                    count += m;
                }
                bitCount = bitCount * 10 + m;
                m *= 10;
            }
            return count;
        }
    }
}
