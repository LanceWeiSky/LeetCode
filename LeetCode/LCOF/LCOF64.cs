using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF64 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //求 1+2+...+n ，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。

        public int SumNums(int n)
        {
            if(n == 1)
            {
                return 1;
            }
            return SumNums(n - 1) + n;
        }
    }
}
