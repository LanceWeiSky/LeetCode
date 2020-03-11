using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF16 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //实现函数double Power(double base, int exponent)，求base的exponent次方。不得使用库函数，同时不需要考虑大数问题。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/shu-zhi-de-zheng-shu-ci-fang-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //考虑n是正数和负数的两种情况


        public class Solution
        {
            public double MyPow(double x, int n)
            {
                if (n < 0)
                {
                    var tmp = Pow(x, -n);
                    if (tmp == 0)
                    {
                        return 0;
                    }
                    return 1d / tmp;
                }
                else
                {
                    return Pow(x, n);
                }
            }

            private double Pow(double x, int n)
            {
                if (n == 0)
                {
                    return 1;
                }
                if (n % 2 == 0)
                {
                    return MyPow(x * x, n / 2);
                }
                else
                {
                    return x * MyPow(x * x, n / 2);
                }
            }
        }
    }
}
