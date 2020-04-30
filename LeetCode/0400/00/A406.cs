using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCode._0400._00
{
    class A406 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[][] ReconstructQueue(int[][] people)
            {
                if (people.Length == 0 || people[0].Length == 0)
                {
                    return people;
                }
                List<int[]> ans = new List<int[]>(people.Length);
                Array.Sort(people, new PeopleComparer());
                foreach (var p in people)
                {
                    ans.Insert(p[1], p);
                }
                return ans.ToArray();
            }

            public class PeopleComparer : IComparer<int[]>
            {
                public int Compare(int[] x, int[] y)
                {
                    int c = y[0].CompareTo(x[0]);
                    if (c == 0)
                    {
                        c = x[1].CompareTo(y[1]);
                    }
                    return c;
                }
            }
        }
    }
}
