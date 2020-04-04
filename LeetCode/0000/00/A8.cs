using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A8 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请你来实现一个 atoi 函数，使其能将字符串转换成整数。

        //首先，该函数会根据需要丢弃无用的开头空格字符，直到寻找到第一个非空格的字符为止。

        //当我们寻找到的第一个非空字符为正或者负号时，则将该符号与之后面尽可能多的连续数字组合起来，作为该整数的正负号；假如第一个非空字符是数字，则直接将其与之后连续的数字字符组合起来，形成整数。

        //该字符串除了有效的整数部分之后也可能会存在多余的字符，这些字符可以被忽略，它们对于函数不应该造成影响。

        //注意：假如该字符串中的第一个非空格字符不是一个有效整数字符、字符串为空或字符串仅包含空白字符时，则你的函数不需要进行转换。

        //在任何情况下，若函数不能进行有效的转换时，请返回 0。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/string-to-integer-atoi
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MyAtoi(string str)
        {
            //cols: space,+-,0~9,other
            int[][] stateTable = new int[][] {
                new int[]{ 1, 2, 3, -1 },//start
                new int[]{ 1, 2, 3, -1 },//space
                new int[]{ -1, -1, 3, -1 },//+-
                new int[]{ 4, 4, 3, 4 },//0~9
                new int[]{ 4, 4, 4, 4 },//final
            };
            int state = 0;
            long num = 0;
            bool sign = false;
            foreach (var c in str)
            {
                state = stateTable[state][GetCol(c)];
                if (state == -1)
                {
                    return 0;
                }
                else if (state == 2)
                {
                    sign = c == '-';
                }
                else if (state == 3)
                {
                    num = num * 10 + (sign ? '0' - c : c - '0');
                    if (num >= int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    else if (num <= int.MinValue)
                    {
                        return int.MinValue;
                    }
                }
                else if (state == 4)
                {
                    break;
                }
            }
            state = stateTable[state][0];
            if (state == 4)
            {
                return (int)num;
            }
            return 0;
        }

        private int GetCol(char c)
        {
            switch (c)
            {
                case ' ':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return 2;
                default:
                    return 3;
            }
        }

        public int MyAtoi_2(string str)
        {
            bool isNegative = false;
            bool isNumStart = false;
            int num = 0;
            int max = int.MaxValue / 10;
            int min = int.MinValue / 10;
            foreach (var c in str)
            {
                if (c >= '0' && c <= '9')
                {
                    isNumStart = true;
                    if (isNegative)
                    {
                        if (num < min)
                        {
                            return int.MinValue;
                        }
                        int temp = '0' - c;
                        num *= 10;
                        if (temp < int.MinValue - num)
                        {
                            return int.MinValue;
                        }
                        num += temp;
                    }
                    else
                    {
                        if (num > max)
                        {
                            return int.MaxValue;
                        }
                        int temp = c - '0';
                        num *= 10;
                        if (temp > int.MaxValue - num)
                        {
                            return int.MaxValue;
                        }
                        num += temp;
                    }
                }
                else
                {
                    if (c == '-')
                    {
                        if (isNumStart)
                        {
                            break;
                        }
                        isNumStart = true;
                        isNegative = true;
                    }
                    else if (c == '+')
                    {
                        if (isNumStart)
                        {
                            break;
                        }
                        isNumStart = true;
                    }
                    else
                    {
                        if (c != ' ' || isNumStart)
                        {
                            break;
                        }
                    }
                }
            }
            return num;
        }
    }
}
