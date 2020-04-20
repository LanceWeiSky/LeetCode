using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A216 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<IList<int>> ans = new List<IList<int>>();
            CombinationSum(ans, 1, 9, k, n, new List<int>());
            return ans;
        }

        private void CombinationSum(List<IList<int>> ans, int start, int end, int k, int n, List<int> path)
        {
            if (k == 0)
            {
                if (n == 0)
                {
                    ans.Add(new List<int>(path));
                }
                return;
            }
            if (n > k * 9)
            {
                return;
            }
            for (int i = start; i <= end; i++)
            {
                path.Add(i);
                CombinationSum(ans, i + 1, end, k - 1, n - i, path);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
