using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A28 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //实现 strStr() 函数。

        //给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置(从0开始)。如果不存在，则返回  -1。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/implement-strstr
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int StrStr(string haystack, string needle)
        {
            if(haystack == null || needle == null)
            {
                return -1;
            }
            if(needle.Length == 0)
            {
                return 0;
            }
            return Sunday(haystack, needle);
        }

        //Sunday算法
        private int Sunday(string text, string pattern)
        {
            int[] shift = new int[256];
            for(int i = 0; i < shift.Length; i++)
            {
                shift[i] = pattern.Length + 1;
            }
            for(int i = 0; i < pattern.Length; i++)
            {
                shift[pattern[i]] = pattern.Length - i;
            }

            int index = 0;
            while(index <= text.Length - pattern.Length)
            {
                int j = 0;
                while(text[index + j] == pattern[j])
                {
                    j++;
                    if(j == pattern.Length)
                    {
                        return index;
                    }
                }
                if (index + pattern.Length >= text.Length)
                {
                    break;
                }
                index += shift[text[index + pattern.Length]];
            }
            return -1;
        }
    }
}
