using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A424 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int CharacterReplacement(string s, int k)
            {
                if (k >= s.Length - 1)
                {
                    return s.Length;
                }

                int[] counter = new int[26];
                int charMax = 0;
                int left = 0;
                for (int right = 0; right < s.Length; right++)
                {
                    counter[s[right] - 'A']++;
                    charMax = Math.Max(charMax, counter[s[right] - 'A']);
                    if (right - left + 1 > charMax + k)
                    {
                        counter[s[left] - 'A']--;
                        left++;
                    }
                }
                return s.Length - left;
            }
        }
    }
}
