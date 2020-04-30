using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0300._80
{
    class A395 : IQuestion
    {
        public void Run()
        {
            new Solution().LongestSubstring("ababbc", 2);
        }

        public class Solution
        {
            public int LongestSubstring(string s, int k)
            {
                return LongestSubstring(s, k, 0, s.Length - 1);
            }

            private int LongestSubstring(string s, int k, int left, int right)
            {
                if (right - left + 1 < k)
                {
                    return 0;
                }
                int[] counter = new int[26];
                for (int i = left; i <= right; i++)
                {
                    counter[s[i] - 'a']++;
                }
                if (counter.All(c => c == 0 || c >= k))
                {
                    return right - left + 1;
                }

                while (right - left + 1 >= k && counter[s[left] - 'a'] < k)
                {
                    left++;
                }

                while (right - left + 1 >= k && counter[s[right] - 'a'] < k)
                {
                    right--;
                }

                if (right - left + 1 < k)
                {
                    return 0;
                }
                int count = 0;
                bool splited = false;
                for (int i = left + 1; i < right; i++)
                {
                    if (counter[s[i] - 'a'] < k)
                    {
                        splited = true;
                        count = Math.Max(count, Math.Max(LongestSubstring(s, k, left, i - 1), LongestSubstring(s, k, i + 1, right)));
                    }
                }
                if (!splited)
                {
                    return right - left + 1;
                }
                return count;
            }
        }
    }
}
