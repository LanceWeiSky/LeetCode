using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF17 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入数字 n，按顺序打印出从 1 到最大的 n 位十进制数。比如输入 3，则打印出 1、2、3 一直到最大的 3 位数 999。


        public class Solution
        {
            public int[] PrintNumbers(int n)
            {
                int max = (int)Math.Pow(10, n);
                int[] ans = new int[max - 1];
                for (int i = 1; i < max; i++)
                {
                    ans[i - 1] = i;
                }
                return ans;
            }
        }
    }
}
