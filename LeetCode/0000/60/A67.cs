using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A67 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个二进制字符串，返回他们的和（用二进制表示）。
        //输入为非空字符串且只包含数字 1 和 0。

        public string AddBinary(string a, string b)
        {
            StringBuilder builder = new StringBuilder();
            int la = a.Length - 1;
            int lb = b.Length - 1;
            bool carry = false;
            while (la >= 0 && lb >= 0)
            {
                if (a[la] == b[lb])
                {
                    builder.Insert(0, carry ? '1' : '0');
                    if (a[la] == '1')
                    {
                        carry = true;
                    }
                    else
                    {
                        carry = false;
                    }
                }
                else
                {
                    if (carry)
                    {
                        builder.Insert(0, '0');
                    }
                    else
                    {
                        builder.Insert(0, '1');
                    }
                }
                la--;
                lb--;
            }
            while (la >= 0)
            {
                if (carry)
                {
                    if (a[la] == '0')
                    {
                        builder.Insert(0, '1');
                        carry = false;
                    }
                    else
                    {
                        builder.Insert(0, '0');
                    }
                }
                else
                {
                    builder.Insert(0, a[la]);
                }
                la--;
            }
            while (lb >= 0)
            {
                if (carry)
                {
                    if (b[lb] == '0')
                    {
                        builder.Insert(0, '1');
                        carry = false;
                    }
                    else
                    {
                        builder.Insert(0, '0');
                    }
                }
                else
                {
                    builder.Insert(0, b[lb]);
                }
                lb--;
            }
            if (carry)
            {
                builder.Insert(0, '1');
            }
            return builder.ToString();
        }
    }
}
