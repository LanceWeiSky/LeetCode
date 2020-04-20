using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A210 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] visited = new int[numCourses];
            Stack<int> ans = new Stack<int>(numCourses);
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
                if (!DFS(ans, visited, i, adj))
                {
                    return new int[0];
                }
            }
            int[] array = new int[numCourses];
            int j = 0;
            while (ans.Count > 0)
            {
                array[j++] = ans.Pop();
            }
            return array;
        }

        private bool DFS(Stack<int> ans, int[] visited, int course, Dictionary<int, List<int>> adj)
        {
            if (visited[course] == -1)
            {
                return true;
            }
            if (visited[course] == 1)
            {
                return false;
            }
            visited[course] = 1;
            if (adj.TryGetValue(course, out var ns))
            {
                foreach (var n in ns)
                {
                    if (!DFS(ans, visited, n, adj))
                    {
                        return false;
                    }
                }
            }
            visited[course] = -1;
            ans.Push(course);
            return true;
        }
    }
}
