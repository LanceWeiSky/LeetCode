using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._20
{
    class A332 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> FindItinerary(IList<IList<string>> tickets)
            {
                Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
                foreach (var ticket in tickets)
                {
                    if (!map.TryGetValue(ticket[0], out var list))
                    {
                        list = new List<string>();
                        map[ticket[0]] = list;
                    }
                    list.Add(ticket[1]);
                }
                foreach (var m in map)
                {
                    m.Value.Sort();
                }

                List<string> ans = new List<string>();
                DFS(ans, map, "JFK");
                ans.Reverse();
                return ans;
            }

            private void DFS(List<string> ans, Dictionary<string, List<string>> map, string from)
            {
                if (map.TryGetValue(from, out var list))
                {
                    while (list.Count > 0)
                    {
                        var to = list[0];
                        list.RemoveAt(0);
                        DFS(ans, map, to);
                    }
                }
                ans.Add(from);
            }
        }
    }
}
