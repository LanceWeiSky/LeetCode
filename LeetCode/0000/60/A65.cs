using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A65 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //验证给定的字符串是否可以解释为十进制数字。

        //例如:

        //"0" => true
        //" 0.1 " => true
        //"abc" => false
        //"1 a" => false
        //"2e10" => true
        //" -90e3   " => true
        //" 1e" => false
        //"e3" => false
        //" 6e-1" => true
        //" 99e2.5 " => false
        //"53.5e93" => true
        //" --6 " => false
        //"-+3" => false
        //"95a54e53" => false

        //说明: 我们有意将问题陈述地比较模糊。在实现代码之前，你应当事先思考所有可能的情况。这里给出一份可能存在于有效十进制数字中的字符列表：


        //	数字 0-9
        //	指数 - "e"
        //	正/负号 - "+"/"-"
        //	小数点 - "."


        //当然，在输入中，这些字符的上下文也很重要。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/valid-number
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool IsNumber(string s)
        {
            //col:blank,+-,.,0~9,e,others
            int[][] stateTable = new int[][] {
                new int[] { 0, 1, 2, 4, -1, -1 },
                new int[] { -1, -1, 2, 4, -1, -1 },//+-
                new int[] { -1, -1, -1, 5, -1, -1 },//.
                new int[] { 9, -1, -1, 5, 6, -1 },//0~9.
                new int[] { 9, -1, 3, 4, 6, -1 },//0~9
                new int[] { 9, -1, -1, 5, 6, -1 },//.0~9
                new int[] { -1, 7, -1, 8, -1, -1 },//e
                new int[] { -1, -1, -1, 8, -1, -1 },//e+-
                new int[] { 9, -1, -1, 8, -1, -1 },//e0~9
                new int[] { 9, -1, -1, -1, -1, -1 },//final

            };

            int state = 0;
            foreach (var c in s)
            {
                state = stateTable[state][GetColIndex(c)];
                if (state == -1)
                {
                    return false;
                }
            }
            state = stateTable[state][0];
            return state == 9;
        }

        private int GetColIndex(char c)
        {
            switch (c)
            {
                case ' ':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '.':
                    return 2;
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
                    return 3;
                case 'e':
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
