using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF50 : IQuestion
    {
        public void Run()
        {
            string input = @"";
            var ans = FirstUniqChar(input);
        }

        //在字符串 s 中找出第一个只出现一次的字符。如果没有，返回一个单空格。



        public char FirstUniqChar(string s)
        {
            int[] count = new int[128];//使用字符的ASCII码作为索引计数
            foreach(var c in s)
            {
                count[c]++;
            }
            foreach(char c in s)
            {
                if(count[c] == 1)
                {
                    return c;
                }
            }
            return ' ';
        }
    }
}
