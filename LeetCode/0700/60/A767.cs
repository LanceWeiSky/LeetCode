using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._60
{
    class A767 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string ReorganizeString(string S)
            {
                int[] counter = new int[26];
                foreach (var c in S)
                {
                    counter[c - 'a'] += 100;
                }
                for(int i = 0; i < counter.Length; i++)
                {
                    counter[i] += i;
                }
                Array.Sort(counter);
                char[] cs = new char[S.Length];
                int index = 1;
                foreach (var count in counter)
                {
                    char ch = (char)(count % 100 + 'a');
                    int ct = count / 100;
                    if (ct > (S.Length + 1) / 2)
                    {
                        return string.Empty;
                    }
                    for (int i = 0; i < ct; i++)
                    {
                        if (index >= S.Length)
                        {
                            index = 0;
                        }
                        cs[index] = ch;
                        index += 2;
                    }
                }
                return new string(cs);
            }
        }
    }
}
