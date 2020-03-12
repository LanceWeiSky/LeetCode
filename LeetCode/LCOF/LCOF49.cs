using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF49 : IQuestion
    {
        public void Run()
        {
            var ans = NthUglyNumber(10);
        }

        //我们把只包含因子 2、3 和 5 的数称作丑数（Ugly Number）。求按从小到大的顺序的第 n 个丑数。

        //思路解析：
        //三指针，p2只计算2的倍数，p3只计算3的倍数，p5只计算5的倍数
        //取最小值，并将指针后移一位

        public int NthUglyNumber(int n)
        {
            int p2 = 0;
            int p3 = 0;
            int p5 = 0;
            int[] pq = new int[n];
            pq[0] = 1;
            for (int i = 1; i < n; i++)
            {
                var v2 = pq[p2] * 2;
                var v3 = pq[p3] * 3;
                var v5 = pq[p5] * 5;
                pq[i] = Math.Min(v2, Math.Min(v3, v5));
                if (pq[i] == v2)
                {
                    p2++;
                }
                if (pq[i] == v3)
                {
                    p3++;
                }
                if (pq[i] == v5)
                {
                    p5++;
                }
            }
            return pq[n - 1];
        }
    }
}
