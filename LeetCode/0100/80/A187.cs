using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._80
{
    class A187 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length < 11)
            {
                return new List<string>();
            }
            Dictionary<char, int> map = new Dictionary<char, int>
            {
                { 'A', 0 },
                { 'C', 1 },
                { 'G', 2 },
                { 'T', 3 },
            };
            int l = 10;
            int hash = 0;
            for (int i = 0; i < l; i++)
            {
                hash <<= 2;
                hash |= map[s[i]];
            }
            HashSet<int> seen = new HashSet<int> { hash };
            HashSet<string> ans = new HashSet<string>();

            int mask = ~(3 << 2 * l);
            for (int i = 1; i < s.Length - l + 1; i++)
            {
                hash = (hash << 2) & mask | map[s[i + l - 1]];
                if (!seen.Add(hash))
                {
                    ans.Add(s.Substring(i, l));
                }
            }
            return ans.ToList();
        }
    }
}
