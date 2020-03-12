using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF65 : IQuestion
    {
        public void Run()
        {
            int a = 123;
            int b = 123;
            if(Add(a, b) != a + b)
            {

            }
        }

        //写一个函数，求两个整数之和，要求在函数体内不得使用 “+”、“-”、“*”、“/” 四则运算符号。

        public int Add(int a, int b)
        {
            //a+b=a^b+(a&b)<<1
            //等式右边还是出现了加号，可以继续递归或者迭代运算
            while(b != 0)
            {
                int c = a ^ b;
                b = (a & b) << 1;
                a = c;
            }
            return a;
        }
    }
}
