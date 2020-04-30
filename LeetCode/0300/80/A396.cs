using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A396 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int MaxRotateFunction(int[] A)
            {
                //f(k+1) = f(k)+S-n*Bk[n-1]
                int sum = 0;
                int f = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    sum += A[i];
                    f += i * A[i];
                }

                int max = f;
                for (int i = A.Length - 1; i > 0; i--)
                {
                    f = f + sum - A.Length * A[i];
                    max = Math.Max(max, f);
                }
                return max;
            }
        }
    }
}
