using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A69 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //实现 int sqrt(int x) 函数。

        //计算并返回 x 的平方根，其中 x 是非负整数。

        //由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/sqrtx
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MySqrt(int x)
        {
            if (x < 2)
            {
                return x;
            }
            double x0 = x;
            double x1 = (x0 + x / x0) / 2d;
            while (Math.Abs(x1 - x0) >= 1)
            {
                x0 = x1;
                x1 = (x0 + x / x0) / 2d;
            }
            return (int)x1;
        }
    }
}
