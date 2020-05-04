using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A433 : IQuestion
    {
        public void Run()
        {
            new Solution().MinMutation("AACCTTGG", "AATTCCGG", new string[] { "AATTCCGG", "AACCTGGG", "AACCCCGG", "AACCTACC" });
        }

        public class Solution
        {
            public int MinMutation(string start, string end, string[] bank)
            {
                HashSet<string> banks = new HashSet<string>(bank);
                if (!banks.Contains(end))
                {
                    return -1;
                }
                int count = 0;
                char[] cs = new char[] { 'A', 'C', 'G', 'T' };
                HashSet<string> positive = new HashSet<string>() { start };
                HashSet<string> negative = new HashSet<string>() { end };
                while (positive.Count > 0 && negative.Count > 0)
                {
                    HashSet<string> next = new HashSet<string>();
                    if (positive.Count > negative.Count)
                    {
                        foreach (var str in negative)
                        {
                            if (positive.Contains(str))
                            {
                                return count;
                            }
                            GetNextMutation(banks, next, str, cs);
                        }
                        negative = next;
                    }
                    else
                    {
                        foreach (var str in positive)
                        {
                            if (negative.Contains(str))
                            {
                                return count;
                            }
                            GetNextMutation(banks, next, str, cs);
                        }
                        positive = next;
                    }
                    count++;
                }

                return -1;
            }

            private void GetNextMutation(HashSet<string> banks, HashSet<string> next, string str, char[] cs)
            {
                var array = str.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    var original = array[i];
                    foreach (var c in cs)
                    {
                        if (c != original)
                        {
                            array[i] = c;
                            string temp = new string(array);
                            if (banks.Contains(temp))
                            {
                                next.Add(temp);
                            }
                        }
                    }
                    array[i] = original;
                }
            }
        }
    }
}
