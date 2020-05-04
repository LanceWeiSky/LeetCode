using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A438 : IQuestion
    {
        public void Run()
        {
            new Solution().FindAnagrams("cbaebabacd", "abc");
        }

        public class Solution
        {
            public IList<int> FindAnagrams(string s, string p)
            {
                int[] needs = new int[26];
                int needCount = 0;
                foreach (var c in p)
                {
                    if (needs[c - 'a'] == 0)
                    {
                        needCount++;
                    }
                    needs[c - 'a']++;
                }
                int[] currents = new int[26];
                int length = p.Length;
                int left = 0, right = 0;
                int valid = 0;
                List<int> ans = new List<int>();
                while (right < s.Length)
                {
                    var c = s[right];
                    currents[c - 'a']++;
                    if (currents[c - 'a'] == needs[c - 'a'])
                    {
                        valid++;
                    }
                    if (valid == needCount)
                    {
                        ans.Add(left);
                    }
                    right++;
                    if (right - left == length)
                    {
                        c = s[left];
                        left++;
                        if (currents[c - 'a'] == needs[c - 'a'])
                        {
                            valid--;
                        }
                        currents[c - 'a']--;
                    }
                }
                return ans;
            }
        }
    }
}
