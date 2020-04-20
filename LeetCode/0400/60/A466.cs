using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._60
{
    class A466 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
            {
                if (n1 == 0)
                {
                    return 0;
                }

                int s1cnt = 0;
                int index = 0;
                int s2cnt = 0;
                Dictionary<int, int[]> recall = new Dictionary<int, int[]>();
                int pre_s1 = 0;
                int pre_s2 = 0;
                int in_s1 = 0;
                int in_s2 = 0;
                while (true)
                {
                    s1cnt++;
                    foreach (var c in s1)
                    {
                        if (s2[index] == c)
                        {
                            index++;
                            if (index == s2.Length)
                            {
                                s2cnt++;
                                index = 0;
                            }
                        }
                    }

                    if (s1cnt == n1)
                    {
                        return s2cnt / n2;
                    }

                    if (recall.TryGetValue(index, out var map))
                    {
                        pre_s1 = s1cnt;
                        pre_s2 = s2cnt;
                        in_s1 = s1cnt - map[0];
                        in_s2 = s2cnt - map[1];
                        break;
                    }
                    else
                    {
                        recall[index] = new int[] { s1cnt, s2cnt };
                    }
                }

                int ans = pre_s2 + (n1 - pre_s1) / in_s1 * in_s2;
                int remain = (n1 - pre_s1) % in_s1;
                for (int i = 0; i < remain; i++)
                {
                    foreach (var c in s1)
                    {
                        if (s2[index] == c)
                        {
                            index++;
                            if (index == s2.Length)
                            {
                                index = 0;
                                ans++;
                            }
                        }
                    }
                }
                return ans / n2;
            }
        }
    }
}
