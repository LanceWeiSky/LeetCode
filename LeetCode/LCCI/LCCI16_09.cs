using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI16_09 : IQuestion
    {
        public void Run()
        {
            var op = new Operations();
            var ans = op.Divide(-9142, 2);
            //ans = op.Divide(-13969484, -5);
            //string path = @"";
            //var str = File.ReadAllLines(path);
            //Utility.InvokeHelper<Operations>(str);

        }

        public class Operations
        {

            public Operations()
            {

            }

            public int Minus(int a, int b)
            {
                return a + ~b + 1;
            }

            public long Abs(long v)
            {
                if (v < 0)
                {
                    return -v;
                }
                return v;
            }

            public int Multiply(int a, int b)
            {
                if (a == 0 || b == 0)
                {
                    return 0;
                }
                if (a == 1)
                {
                    return b;
                }
                if (a == -1)
                {
                    return -b;
                }
                if(b == 1)
                {
                    return a;
                }
                if(b == -1)
                {
                    return -a;
                }
                int sign = 1;
                if (a < 0 && b > 0 || a > 0 && b < 0)
                {
                    sign = -1;
                }
                var a2 = Abs(a);
                var b2 = Abs(b);
                if (a2 < b2)
                {
                    var t = a2;
                    a2 = b2;
                    b2 = t;
                }
                int ret = 0;
                int t2 = 0;
                while (t2 < b2)
                {
                    var temp = 1;
                    var tempA = a2;
                    while (temp + temp + t2 <= b2)
                    {
                        temp += temp;
                        tempA += tempA;
                    }
                    t2 += temp;
                    ret += (int)tempA;
                }
                if(sign < 0)
                {
                    return -ret;
                }
                return ret;
            }

            public int Divide(int a, int b)
            {
                if(a == 0)
                {
                    return 0;
                }
                if (b == 1)
                {
                    return a;
                }
                if(b == -1)
                {
                    return -a;
                }
                int sign = 1;
                if (a < 0 && b > 0 || a > 0 && b < 0)
                {
                    sign = -1;
                }
                var a2 = Abs(a);
                var b2 = Abs(b);
                int ret = 0;
                long tempB2 = 0;
                while (a2 >= tempB2 + b2)
                {
                    int r = 1;
                    var tempB = b2;
                    while (a2 >= tempB + tempB + tempB2)
                    {
                        tempB += tempB;
                        r += r;
                    }
                    tempB2 += tempB;
                    ret += r;
                }
                return sign > 0 ? ret : -ret;
            }
        }
    }
}
