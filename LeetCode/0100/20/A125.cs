using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A125 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。
        //说明：本题中，我们将空字符串定义为有效的回文串。

        public bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                while (i < j && !Char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                while (i < j && !Char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }
                if (i < j)
                {
                    var c1 = char.ToLower(s[i++]);
                    var c2 = char.ToLower(s[j--]);
                    if (c1 != c2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
