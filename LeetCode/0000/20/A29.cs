using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A29 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。

        //返回被除数 dividend 除以除数 divisor 得到的商。

        //整数除法的结果应当截去（truncate）其小数部分，例如：truncate(8.345) = 8 以及 truncate(-2.7335) = -2



        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/divide-two-integers
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int Divide(int dividend, int divisor)
        {
            //全部转换为负数，防止越界
            bool sign = (dividend > 0) ^ (divisor > 0);
            if(dividend > 0)
            {
                dividend = -dividend;
            }
            if(divisor > 0)
            {
                divisor = -divisor;
            }
            int result = 0;
            while(dividend <= divisor)
            {
                int tempDivisor = divisor;
                int tempResult = -1;
                while(dividend <= (tempDivisor << 1))
                {
                    if(tempDivisor < (int.MinValue >> 1))
                    {
                        break;
                    }
                    tempDivisor = tempDivisor << 1;
                    tempResult = tempResult << 1;
                }
                dividend -= tempDivisor;
                result += tempResult;
            }
            if(sign)
            {
                return result;
            }
            if(result == int.MinValue)
            {
                return int.MaxValue;
            }
            return -result;
        }
    }
}
