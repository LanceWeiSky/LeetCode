using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0000._40
{
    class A49 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 0)
            {
                return new List<IList<string>>();
            }
            Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
            foreach(var s in strs)
            {
                var k = GetKey(s);
                if (groups.TryGetValue(k, out var l))
                {
                    l.Add(s);
                }
                else
                {
                    groups[k] = new List<string> { s };
                }
            }
            return groups.Values.ToList();
        }

        private string GetKey(string str)
        {
            int[] cs = new int[26];
            foreach(var c in str)
            {
                cs[c - 'a']++;
            }
            return string.Join('_', cs);
        }
    }
}
