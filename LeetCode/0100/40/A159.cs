using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._40
{
    class A159 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LengthOfLongestSubstringTwoDistinct(string s)
            {
                if(s.Length < 3)
                {
                    return s.Length;
                }
                Dictionary<char, int> map = new Dictionary<char, int>(3);
                int left = 0, right = 0, ans = 0;
                while (right < s.Length)
                {
                    var c = s[right];
                    if (map.ContainsKey(c))
                    {
                        map[c] = right;
                    }
                    else
                    {
                        map.Add(c, right);
                    }
                    if (map.Count == 3)
                    {
                        int min = map.Min(selector => selector.Value);
                        map.Remove(s[min]);
                        left = min + 1;
                    }
                    right++;
                    ans = Math.Max(ans, right - left);
                }
                return ans;
            }
        }
    }
}
