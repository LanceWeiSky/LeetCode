using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A96 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？

        //catalan
        public int NumTrees(int n)
        {
            long ans = 1;
            for (int i = 1; i <= n; i++)
            {
                ans = (4 * i - 2) * ans / (i + 1);
            }
            return (int)ans;
        }
    }
}
