using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A3 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>(s.Length);
            int max = 0;
            int leftIndex = 0;
            int index = 0;
            int i = 0;
            while (i < s.Length)
            {
                char c = s[i];
                if (chars.TryGetValue(c, out index) && index >= leftIndex)//利用字符缓存，不必每次重新查找，重复时只要将索引设置为上次重复字符的下一个字符即可
                {
                    var tempMax = i - leftIndex;
                    if (tempMax > max)
                    {
                        max = tempMax;
                    }
                    leftIndex = index + 1;
                    if (s.Length - leftIndex <= max)
                    {
                        break;
                    }
                }
                chars[c] = i;
                i++;
            }
            if (i == s.Length)
            {
                var tempMax = i - leftIndex;
                if (tempMax > max)
                {
                    max = tempMax;
                }
            }
            return max;
        }
    }
}
