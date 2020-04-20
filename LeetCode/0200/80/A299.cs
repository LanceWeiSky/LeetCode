using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A299 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string GetHint(string secret, string guess)
            {
                int a = 0;
                int[] bucket = new int[10];
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        a++;
                    }
                    else
                    {
                        bucket[secret[i] - '0']++;
                    }
                }

                int b = 0;
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] != guess[i])
                    {
                        if (bucket[guess[i] - '0'] > 0)
                        {
                            b++;
                            bucket[guess[i] - '0']--;
                        }
                    }
                }
                return $"{a}A{b}B";
            }
        }
    }
}
