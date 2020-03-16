using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A7 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

        public int Reverse(int x)
        {
            long ans = 0;
            while(x != 0)
            {
                var m = x % 10;
                ans = ans * 10 + m;
                x /= 10;
            }
            if(ans > int.MaxValue || ans < int.MinValue)
            {
                return 0;
            }
            return (int)ans;
        }
    }
}
