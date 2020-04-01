using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A43 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。

        //示例 1:

        //输入: num1 = "2", num2 = "3"
        //输出: "6"

        //示例 2:

        //输入: num1 = "123", num2 = "456"
        //输出: "56088"

        //说明：


        //	num1 和 num2 的长度小于110。

        //    num1 和 num2 只包含数字 0-9。

        //    num1 和 num2 均不以零开头，除非是数字 0 本身。
        //	不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/multiply-strings
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            int[] sums = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int n1 = num1[i] - '0';
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int n2 = num2[j] - '0';
                    var sum = sums[i + j + 1] + n1 * n2;
                    sums[i + j + 1] = sum % 10;
                    sums[i + j] += sum / 10;
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach (var n in sums)
            {
                if (n == 0 && builder.Length == 0)
                {
                    continue;
                }
                builder.Append(n.ToString());
            }
            return builder.ToString();
        }

    }
}
