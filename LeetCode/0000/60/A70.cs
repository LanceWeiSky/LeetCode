using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A70 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
        //每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
        //注意：给定 n 是一个正整数。

        public int ClimbStairs(int n)
        {
            if (n < 3)
            {
                return n;
            }
            int ans = 0;
            int f0 = 1;
            int f1 = 1;
            for (int i = 1; i < n; i++)
            {
                ans = f0 + f1;
                f0 = f1;
                f1 = ans;
            }
            return ans;
        }
    }
}
