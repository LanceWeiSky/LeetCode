using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A383 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool CanConstruct(string ransomNote, string magazine)
            {
                int[] counter = new int[26];
                foreach (var c in magazine)
                {
                    counter[c - 'a']++;
                }
                foreach (var c in ransomNote)
                {
                    var index = c - 'a';
                    if (counter[index] == 0)
                    {
                        return false;
                    }
                    counter[index]--;
                }
                return true;
            }
        }
    }
}
