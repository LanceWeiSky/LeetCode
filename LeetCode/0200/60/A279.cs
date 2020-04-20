using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A279 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int NumSquares(int n)
            {
                HashSet<int> seen = new HashSet<int>();
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(n);
                int level = 0;
                while (queue.Count > 0)
                {
                    level++;
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var num = queue.Dequeue();
                        for (int j = 1; j * j <= num; j++)
                        {
                            var next = num - j * j;
                            if (next == 0)
                            {
                                return level;
                            }
                            if (seen.Add(next))
                            {
                                queue.Enqueue(next);
                            }
                        }
                    }
                }
                return -1;
            }
        }
    }
}
