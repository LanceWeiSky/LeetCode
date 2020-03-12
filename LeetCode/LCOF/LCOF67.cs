using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF67 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //写一个函数 StrToInt，实现把字符串转换成整数这个功能。不能使用 atoi 或者其他类似的库函数。

        public int StrToInt(string str)
        {
            int n = 0;
            bool isNumberStart = false;
            bool isNe = false;
            foreach (var c in str)
            {
                if (c == ' ')
                {
                    if (isNumberStart)
                    {
                        break;
                    }
                }
                else if (c >= '0' && c <= '9')
                {
                    if (!isNumberStart)
                    {
                        isNumberStart = true;
                        n = c - '0';
                        if (isNe)
                        {
                            n = -n;
                        }
                        continue;
                    }
                    var t = 0;
                    var maxValue = 0;
                    if (isNe)
                    {
                        if(int.MinValue / 10 > n)
                        {
                            return int.MinValue;
                        }
                        n *= 10;
                        maxValue = int.MinValue - n;
                        t = '0' - c;
                        if(t <= maxValue)
                        {
                            return int.MinValue;
                        }
                    }
                    else
                    {
                        if(int.MaxValue / 10 < n)
                        {
                            return int.MaxValue;
                        }
                        n *= 10;
                        maxValue = int.MaxValue - n;
                        t = c - '0';
                        if(t >= maxValue)
                        {
                            return int.MaxValue;
                        }
                    }

                    n += t;
                }
                else if (c == '-')
                {
                    if (isNumberStart)
                    {
                        break;
                    }
                    isNumberStart = true;
                    isNe = true;
                }
                else if (c == '+')
                {
                    if (isNumberStart)
                    {
                        break;
                    }
                    isNumberStart = true;
                }
                else
                {
                    break;
                }
            }
            return n;
        }
    }
}
