using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF5 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //请实现一个函数，把字符串 s 中的每个空格替换成"%20"。

        public string ReplaceSpace(string s)
        {
            StringBuilder builder = new StringBuilder(s.Length * 3);
            foreach (var c in s)
            {
                if (c == ' ')
                {
                    builder.Append("%20");
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
}
