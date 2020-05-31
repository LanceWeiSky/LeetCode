using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1100._40
{
    class A1156 : IQuestion
    {
        public void Run()
        {
            new Solution().MaxRepOpt1("bbababaaaa");
        }

        public class Solution
        {
            public int MaxRepOpt1(string text)
            {
                int ans = 1;
                int[] counter = new int[26];
                int[] left = new int[text.Length];
                int[] right = new int[text.Length];
                int count = 1;
                char prev = text[0];
                for (int i = 1; i < text.Length; i++)
                {
                    if (text[i] == prev)
                    {
                        count++;
                    }
                    else
                    {
                        ans = Math.Max(ans, count);
                        counter[prev - 'a'] += count;
                        right[i - 1] = count;
                        left[i - count] = count;
                        count = 1;
                        prev = text[i];
                    }
                }
                ans = Math.Max(ans, count);
                counter[prev - 'a'] += count;
                right[text.Length - 1] = count;
                left[text.Length - count] = count;
                for (int i = 1; i < text.Length - 1; i++)
                {
                    if (counter[text[i] - 'a'] > left[i])
                    {
                        ans = Math.Max(ans, left[i] + 1);
                    }
                    if (counter[text[i] - 'a'] > right[i])
                    {
                        ans = Math.Max(ans, right[i] + 1);
                    }
                    if (text[i - 1] == text[i + 1] && text[i - 1] != text[i])
                    {
                        var temp = left[i + 1] + right[i - 1];
                        if (counter[text[i + 1] - 'a'] > temp)
                        {
                            temp++;
                        }
                        ans = Math.Max(ans, temp);
                    }
                }
                return ans;
            }
        }
    }
}
