using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._40
{
    class A151 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串，逐个翻转字符串中的每个单词。

        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(' ', words);
        }
    }
}
