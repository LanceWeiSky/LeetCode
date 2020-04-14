using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LeetCode._0100._20
{
    class A131 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
        //返回 s 所有可能的分割方案。

        public IList<IList<string>> Partition(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                InitializeDP(s, i, i, dp);
                InitializeDP(s, i, i + 1, dp);
            }
            List<IList<string>> ans = new List<IList<string>>();
            PartitionInternal(ans, s, 0, dp, new List<string>());
            return ans;
        }

        private void PartitionInternal(List<IList<string>> ans, string s, int index, bool[,] dp, List<string> path)
        {
            if (index == s.Length)
            {
                ans.Add(new List<string>(path));
                return;
            }
            for (int i = index; i < s.Length; i++)
            {
                if (dp[index, i])
                {
                    path.Add(s.Substring(index, i - index + 1));
                    PartitionInternal(ans, s, i + 1, dp, path);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        private void InitializeDP(string s, int left, int right, bool[,] dp)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] == s[right])
                {
                    dp[left--, right++] = true;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
