using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._20
{
    class A727 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string MinWindow(string S, string T)
            {
                int[,] next = new int[S.Length, 26];
                for (int i = 0; i < 26; i++)
                {
                    int index = -1;
                    for (int j = S.Length - 1; j >= 0; j--)
                    { 
                        if(S[j] - 'a' == i)
                        {
                            index = j;
                        }
                        next[j, i] = index;
                    }
                }
                int start = -1;
                int endIndex = -1;
                int minLength = int.MaxValue;
                int minStart = -1;
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] == T[0])
                    {
                        start = i;
                        endIndex = i;
                        for (int j = 1; j < T.Length; j++)
                        {
                            if (endIndex < S.Length - 1 && next[endIndex + 1, T[j] - 'a'] >= 0)
                            {
                                endIndex = next[endIndex + 1, T[j] - 'a'];
                            }
                            else
                            {
                                start = -1;
                                endIndex = -1;
                                break;
                            }
                        }
                        if(start >= 0 && endIndex - start + 1 < minLength)
                        {
                            minLength = endIndex - start + 1;
                            minStart = start;
                        }
                    }
                }
                if(minStart < 0)
                {
                    return string.Empty;
                }
                return S.Substring(minStart, minLength);
            }
        }
    }
}
