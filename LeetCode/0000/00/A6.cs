using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A6 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。

        //比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：

        //L   C   I   R
        //E T O E S I I G
        //E   D   H   N


        //之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。

        //请你实现这个将字符串进行指定行数变换的函数：

        //string convert(string s, int numRows);

        //        来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/zigzag-conversion
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public string Convert(string s, int numRows)
        {
            if(numRows == 1)
            {
                return s;
            }
            StringBuilder[] rows = new StringBuilder[Math.Min(s.Length, numRows)];
            for(int i = 0; i < rows.Length; i ++)
            {
                rows[i] = new StringBuilder();
            }
            bool down = true;
            int row = 0;
            foreach(var c in s)
            {
                rows[row].Append(c);
                if(down)
                {
                    row++;
                }
                else
                {
                    row--;
                }
                if(row == 0)
                {
                    down = true;
                }
                else if(row == numRows - 1)
                {
                    down = false;
                }
            }
            StringBuilder builder = new StringBuilder();
            foreach(var temp in rows)
            {
                builder.Append(temp);
            }
            return builder.ToString();
        }
    }
}
