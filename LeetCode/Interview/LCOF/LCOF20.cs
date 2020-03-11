using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF20 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请实现一个函数用来判断字符串是否表示数值（包括整数和小数）。
        //例如，字符串"+100"、"5e2"、"-123"、"3.1416"、"0123"及"-1E-16"都表示数值，但"12e"、"1a3.14"、"1.2.3"、"+-5"及"12e+5.4"都不是。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/biao-shi-shu-zhi-de-zi-fu-chuan-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        public class Solution
        {
            public bool IsNumber(string s)
            {
                var isNumber = IsNumber(s, 0, s.Length, out var isSigned, out var isPoint, out var eOffset);
                if (isNumber && eOffset > 0)
                {
                    isNumber = IsNumber(s, eOffset + 1, s.Length - eOffset - 1, out isSigned, out isPoint, out eOffset);
                    isNumber = isNumber && !isPoint && eOffset < 0;
                }
                return isNumber;
            }

            private bool IsNumber(string s, int offset, int length, out bool isSigned, out bool isPoint, out int eOffset)
            {
                eOffset = -1;
                isSigned = false;
                isPoint = false;
                bool isNumberStart = false;
                bool isNumber = false;
                bool hasSpace = false;
                for (int i = offset; i < length + offset; i++)
                {
                    if (s[i] == ' ')
                    {
                        if (isNumberStart)
                        {
                            hasSpace = true;
                        }
                    }
                    else
                    {
                        if (hasSpace)
                        {
                            return false;
                        }
                        if (s[i] <= '9' && s[i] >= '0')
                        {
                            isNumberStart = true;
                            isNumber = true;
                        }
                        else if (s[i] == '+' || s[i] == '-')
                        {
                            if (isNumberStart)
                            {
                                return false;
                            }
                            isNumberStart = true;
                            isSigned = true;
                        }
                        else if (s[i] == '.')
                        {
                            if (isPoint)
                            {
                                return false;
                            }
                            isNumberStart = true;
                            isPoint = true;
                            //isNumber = false;
                        }
                        else if (s[i] == 'e' || s[i] == 'E')
                        {
                            eOffset = i;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return isNumber;
            }
        }
    }
}
