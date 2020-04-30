using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._00
{
    class A310 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                if (n == 1)
                {
                    return new List<int> { 0 };
                }
                int[] degree = new int[n];
                Dictionary<int, List<int>> nexts = new Dictionary<int, List<int>>();
                foreach (var edge in edges)
                {
                    degree[edge[0]]++;
                    degree[edge[1]]++;
                    if (!nexts.TryGetValue(edge[0], out var next))
                    {
                        next = new List<int>();
                        nexts[edge[0]] = next;
                    }
                    next.Add(edge[1]);
                    if (!nexts.TryGetValue(edge[1], out next))
                    {
                        next = new List<int>();
                        nexts[edge[1]] = next;
                    }
                    next.Add(edge[0]);
                }

                Queue<int> queue = new Queue<int>();
                for(int i = 0; i < n; i++)
                {
                    if (degree[i] == 1)
                    {
                        queue.Enqueue(i);
                    }
                }

                List<int> ans = new List<int>();
                while (queue.Count > 0)
                {
                    ans.Clear();
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        ans.Add(temp);
                        if (nexts.TryGetValue(temp, out var next))
                        {
                            foreach (var ne in next)
                            {
                                degree[ne]--;
                                if (degree[ne] == 1)
                                {
                                    queue.Enqueue(ne);
                                }
                            }
                        }

                    }
                }
                return ans;
            }
        }
    }
}
