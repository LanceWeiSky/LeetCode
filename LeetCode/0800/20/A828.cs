using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0800._20
{
    class A828 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int UniqueLetterString(string s)
            {
                if (s.Length < 2)
                {
                    return s.Length;
                }
                List<int>[] counter = new List<int>[26];
                for (int i = 0; i < s.Length; i++)
                {
                    var index = s[i] - 'A';
                    if (counter[index] == null)
                    {
                        counter[index] = new List<int> { -1, i };
                    }
                    else
                    {
                        counter[index].Add(i);
                    }
                }
                int ans = 0;
                foreach (var idxes in counter)
                {
                    if (idxes == null)
                    {
                        continue;
                    }
                    idxes.Add(s.Length);
                    for (int i = 1; i < idxes.Count - 1; i++)
                    {
                        ans += (idxes[i] - idxes[i - 1]) * (idxes[i + 1] - idxes[i]);
                    }
                }
                return ans;
            }
        }
    }
}
