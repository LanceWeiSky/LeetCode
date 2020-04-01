using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A50 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //实现 pow(x, n) ，即计算 x 的 n 次幂函数。

        public double MyPow(double x, int n)
        {
            if(x == 0)
            {
                return 0;
            }
            if(n < 0)
            {
                long tn = n;
                tn = -tn;
                return Pow(1d / x, tn);
            }
            return Pow(x, n);
        }

        private double Pow(double x, long n)
        {
            double result = 1;
            double tempX = x;
            for (long i = n; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    result *= tempX;
                }
                tempX *= tempX;
            }
            if (double.IsInfinity(result))
            {
                return 0;
            }
            return result;
        }
    }
}
