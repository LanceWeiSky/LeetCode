using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LeetCode._0200._00
{
    class A207 : IQuestion
    {
        public void Run()
        {
            var ans = CanFinish(2, new int[][] { new int[] { 0, 1 } });
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] indegree = new int[numCourses];
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            foreach (var pre in prerequisites)
            {
                indegree[pre[0]]++;
                if (adj.TryGetValue(pre[1], out var ns))
                {
                    ns.Add(pre[0]);
                }
                else
                {
                    adj[pre[1]] = new List<int> { pre[0] };
                }
            }

            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                numCourses--;
                if (adj.TryGetValue(c, out var ns))
                {
                    foreach (var n in ns)
                    {
                        indegree[n]--;
                        if (indegree[n] == 0)
                        {
                            queue.Enqueue(n);
                        }
                    }
                }

            }
            return numCourses == 0;
        }

        public bool CanFinish_1(int numCourses, int[][] prerequisites)
        {
            int[] visited = new int[numCourses];//1.当前遍历在访问。-1.历史遍历访问过。
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            foreach (var pre in prerequisites)
            {
                if (adj.TryGetValue(pre[1], out var ns))
                {
                    ns.Add(pre[0]);
                }
                else
                {
                    adj[pre[1]] = new List<int> { pre[0] };
                }
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (!DFS(visited, i, adj))
                {
                    return false;
                }
            }
            return true;
        }

        private bool DFS(int[] visited, int course, Dictionary<int, List<int>> adj)
        {
            if (visited[course] == 1)
            {
                return false;
            }
            if (visited[course] == -1)
            {
                return true;
            }
            visited[course] = 1;
            if (adj.TryGetValue(course, out var nexts))
            {
                foreach (var n in nexts)
                {
                    if (!DFS(visited, n, adj))
                    {
                        return false;
                    }
                }
            }
            visited[course] = -1;
            return true;
        }

    }
}
