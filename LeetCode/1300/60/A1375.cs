using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1300._60
{
    class A1375 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NumTimesAllBlue(int[] light)
            {
                int count = 0;
                int max = -1;
                for (int i = 0; i < light.Length; i++)
                {
                    max = Math.Max(max, light[i]);
                    if (max == i + 1)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
