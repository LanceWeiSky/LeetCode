using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1000._00
{
    class A1004 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int LongestOnes(int[] A, int K)
            {
                int left = 0;
                int right = 0;
                int max = 0;
                while (right < A.Length)
                { 
                    if(A[right++] == 0)
                    {
                        if (K > 0)
                        {
                            K--;
                        }
                        else
                        {
                            max = Math.Max(max, right - left);
                            while (A[left++] == 1) { }
                        }
                    }
                }
                max = Math.Max(max, right - left);
                return max;
            }
        }
    }
}
