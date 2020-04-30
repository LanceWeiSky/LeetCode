using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._60
{
    class A372 : IQuestion
    {
        public void Run()
        {
            
        }

        public class Solution
        {
            public const int MOD = 1337;

            public int SuperPow(int a, int[] b)
            {
                a = a % MOD;
                return SuperPow(a, b, b.Length - 1);
            }

            private int SuperPow(int a, int[] b, int end)
            {
                int p = Pow(a, b[end]);
                if (end > 0)
                {
                    var p2 = Pow(SuperPow(a, b, end - 1), 10);
                    p = (p * p2) % MOD;
                }
                return p;
            }

            private int Pow(int a, int b)
            {
                if (b == 0)
                {
                    return 1;
                }
                int p = 1;
                while (b != 0)
                {
                    if ((b & 1) == 1)
                    {
                        p = (p * a) % MOD;
                        b--;
                    }
                    else
                    {
                        b /= 2;
                        a = (a * a) % MOD;
                    }
                }
                return p;
            }
        }
    }
}
