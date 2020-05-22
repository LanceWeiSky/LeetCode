using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._60
{
    class A567 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CheckInclusion(string s1, string s2)
            {
                if (s1.Length > s2.Length)
                {
                    return false;
                }
                int[] counter1 = new int[26];
                foreach (var c in s1)
                {
                    counter1[c - 'a']++;
                }
                int count = 0;
                foreach (var c in counter1)
                {
                    if (c == 0)
                    {
                        count++;
                    }
                }
                int[] counter2 = new int[26];
                int left = 0;
                int right = 0;
                while (right < s2.Length)
                {
                    var rc = s2[right];
                    counter2[rc - 'a']++;
                    if (counter2[rc - 'a'] == counter1[rc - 'a'])
                    {
                        count++;
                    }
                    else if (counter2[rc - 'a'] == counter1[rc - 'a'] + 1)
                    {
                        count--;
                    }

                    if (right - left == s1.Length)
                    {
                        var lc = s2[left];
                        counter2[lc - 'a']--;
                        if (counter2[lc - 'a'] == counter1[lc - 'a'])
                        {
                            count++;
                        }
                        else if (counter2[lc - 'a'] == counter1[lc - 'a'] - 1)
                        {
                            count--;
                        }
                        left++;
                    }
                    right++;
                    if (count == 26)
                    {
                        return true;
                    }
                }
                return count == 26;
            }
        }
    }
}
