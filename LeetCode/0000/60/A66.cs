using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A66 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。

        //最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。

        //你可以假设除了整数 0 之外，这个整数不会以零开头。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/plus-one
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length - 1;
            digits[n]++;
            while (digits[n] > 9)
            {
                digits[n] = 0;
                n--;
                if (n < 0)
                {
                    int[] temp = new int[digits.Length + 1];
                    temp[0] = 1;
                    //Array.Copy(digits, 0, temp, 1, digits.Length);//all is 0
                    return temp;
                }
                else
                {
                    digits[n]++;
                }
            }
            return digits;
        }
    }
}
