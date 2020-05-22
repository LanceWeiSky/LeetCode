using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._80
{
    class A680 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool ValidPalindrome(string s)
            {
                int left = 0, right = s.Length - 1;
                while (left < right)
                {
                    if (s[left] == s[right])
                    {
                        left++;
                        right--;
                    }
                    else
                    {
                        return IsPalindrome(s, left, right - 1) || IsPalindrome(s, left + 1, right);
                    }
                }
                return true;
            }

            private bool IsPalindrome(string s, int i, int j)
            {
                while (i < j)
                {
                    if (s[i++] != s[j--])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
