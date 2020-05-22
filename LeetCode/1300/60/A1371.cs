using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1300._60
{
    class A1371 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int FindTheLongestSubstring(string s)
            {
                int[] startIndex = new int[1 << 5];
                Array.Fill(startIndex, int.MaxValue);
                startIndex[0] = -1;
                int ans = 0;
                int state = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case 'a':
                            state ^= 1;
                            break;
                        case 'e':
                            state ^= 1 << 1;
                            break;
                        case 'i':
                            state ^= 1 << 2;
                            break;
                        case 'o':
                            state ^= 1 << 3;
                            break;
                        case 'u':
                            state ^= 1 << 4;
                            break;
                    }
                    if (startIndex[state] == int.MaxValue)
                    {
                        startIndex[state] = i;
                    }
                    ans = Math.Max(ans, i - startIndex[state]);
                }
                return ans;
            }
        }
    }
}
