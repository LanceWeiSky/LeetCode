using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A204 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int CountPrimes(int n)
        {
            bool[] isPrimes = new bool[n];
            Array.Fill(isPrimes, true);
            var max = (int)Math.Sqrt(n);
            for (int i = 2; i <= max; i++)
            {
                if (isPrimes[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        isPrimes[j] = false;
                    }
                }
            }
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrimes[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
