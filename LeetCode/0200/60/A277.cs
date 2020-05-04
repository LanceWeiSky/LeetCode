using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A277 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Relation
        {
            public bool Knows(int a, int b)
            {
                return false;
            }
        }

        public class Solution : Relation
        {
            public int FindCelebrity(int n)
            {
                int i = 0;
                for (int j = 1; j < n; j++)
                {
                    if (Knows(i, j))
                    {
                        i = j;
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (Knows(i, j))
                    {
                        return -1;
                    }
                    if (!Knows(j, i))
                    {
                        return -1;
                    }
                }
                return i;
            }
        }
    }
}
