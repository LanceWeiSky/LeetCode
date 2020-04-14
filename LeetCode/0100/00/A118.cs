using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A118 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非负整数 numRows，生成杨辉三角的前 numRows 行。

        public IList<IList<int>> Generate(int numRows)
        {
            if (numRows == 0)
            { 
                return new List<IList<int>>();
            }
            List<IList<int>> ans = new List<IList<int>>(numRows);
            var pre = new List<int> { 1 };
            ans.Add(pre);
            for (int i = 1; i < numRows; i++)
            {
                List<int> cur = new List<int>(pre.Count + 1);
                cur.Add(1);
                for (int j = 1; j < pre.Count; j++)
                {
                    cur.Add(pre[j] + pre[j - 1]);
                }
                cur.Add(1);
                pre = cur;
                ans.Add(cur);
            }
            return ans;
        }
    }
}
