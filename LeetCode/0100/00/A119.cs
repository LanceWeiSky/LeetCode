using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A119 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。

        public IList<int> GetRow(int rowIndex)
        {
            List<int> ans = new List<int>(rowIndex + 1);
            ans.Add(1);
            if(rowIndex == 0)
            {
                return ans;
            }
            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    ans[j] = ans[j] + ans[j - 1];
                }
                ans.Add(1);
            }
            return ans;
        }
    }
}
