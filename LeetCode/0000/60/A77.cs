using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A77 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。

        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> ans = new List<IList<int>>();
            int[] temp = new int[k];
            Combine(ans, 1, n - k + 1, 0, temp);
            return ans;
        }

        private void Combine(List<IList<int>> ans, int startNum, int endNum, int index, int[] temp)
        {
            if (index == temp.Length)
            {
                ans.Add(new List<int>(temp));
                return;
            }
            for (int i = startNum; i <= endNum; i++)
            {
                temp[index] = i;
                Combine(ans, i + 1, endNum + 1, index + 1, temp);
            }
        }
    }
}
