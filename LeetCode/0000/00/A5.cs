using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A5 : IQuestion
    {
        public void Run()
        {
            var ans = LongestPalindrome("cbbd");
        }

        //给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

        public string LongestPalindrome(string s)
        {
            return Manacher(s);
        }

        //Manacher算法
        private string Manacher(string s)
        {
            //使用#将字符串分开，方便处理奇数与偶数的情况，前后加任意不相同的字符，方便处理越界。
            StringBuilder temp = new StringBuilder("$#");
            foreach(var c in s)
            {
                temp.Append(c);
                temp.Append("#");
            }
            temp.Append('\0');
            var str = temp.ToString();
            int maxLength = 0;
            int maxIndex = 0;
            int id = 0;
            int mx = 0;
            int[] p = new int[str.Length];//存储新的字符串回文半径长度，原始回文长度=新半径长度-1
            for(int i = 1; i < str.Length - 1; i++)
            {
                if(i < mx)
                {
                    p[i] = Math.Min(p[2 * id - i], mx - i);//i在回文半径内，可直接获取相对于id的对称点回文半径，若超过mx-i，则mx之后的部分无法预测，需要重新计算
                }
                else
                {
                    p[i] = 1;
                }
                while (str[i - p[i]] == str[i + p[i]])//重新计算超出mx之后的回文半径长度
                {
                    p[i]++;
                }
                if(p[i] > maxLength)
                {
                    maxLength = p[i];
                    maxIndex = i;
                }
                if(i + p[i] > mx)//尽量使mx靠后，匹配概率更高
                {
                    mx = i + p[i];
                    id = i;
                }
            }
            return s.Substring((maxIndex - maxLength) / 2, maxLength - 1);
        }
    }
}
