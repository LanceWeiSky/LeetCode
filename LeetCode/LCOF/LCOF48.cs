using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF48 : IQuestion
    {
        public void Run()
        {
            var ans = LengthOfLongestSubstring("bbbbbb");
        }

        //请从字符串中找出一个最长的不包含重复字符的子字符串，计算该最长子字符串的长度。

        public int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }
            Dictionary<char, int> cache = new Dictionary<char, int>(s.Length);//记录每次字符出现的位置
            int left = 0;
            int right = 0;
            int ans = 0;
            while(right < s.Length)
            {
                if(cache.TryGetValue(s[right], out var index) && index >= left)
                {
                    ans = Math.Max(ans, right - left);
                    left = index + 1;//出现重复字符后不需要每次从新开始计算，只需要从重复的下一位计算即可
                }
                cache[s[right]] = right;
                right++;
            }
            ans = Math.Max(ans, right - left);
            return ans;
        }
    }
}
