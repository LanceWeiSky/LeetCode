using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A413 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NumberOfArithmeticSlices(int[] A)
            {
                int length = 0;
                int count = 0;
                for (int i = 2; i < A.Length; i++)
                {
                    if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                    {
                        length++;
                    }
                    else
                    {
                        count += (length + 1) * length / 2;
                        length = 1;
                    }
                }
                count += (length + 1) * length / 2;
                return count;
            }
        }
    }
}
