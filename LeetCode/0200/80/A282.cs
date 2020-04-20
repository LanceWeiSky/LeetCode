using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0200._80
{
    class A282 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> AddOperators(string num, int target)
            {
                List<string> ans = new List<string>();
                AddOperators(ans, num, target, 0, 0, 0, 0, new List<string>());
                return ans;
            }

            private void AddOperators(List<string> ans, string num, int target, int index, long prev, long cur, long value, List<string> path)
            {
                if (index == num.Length)
                {
                    if (value == target && cur == 0)
                    {
                        ans.Add(string.Concat(path.Skip(1)));
                    }
                    return;
                }

                cur = cur * 10 + (num[index] - '0');
                if (cur > 0)
                {
                    AddOperators(ans, num, target, index + 1, prev, cur, value, path);
                }
                string curStr = cur.ToString();

                path.Add("+");
                path.Add(curStr);
                AddOperators(ans, num, target, index + 1, cur, 0, value + cur, path);
                path.RemoveAt(path.Count - 1);
                path.RemoveAt(path.Count - 1);


                if (path.Count > 0)
                {
                    path.Add("-");
                    path.Add(curStr);
                    AddOperators(ans, num, target, index + 1, -cur, 0, value - cur, path);
                    path.RemoveAt(path.Count - 1);
                    path.RemoveAt(path.Count - 1);

                    path.Add("*");
                    path.Add(curStr);
                    AddOperators(ans, num, target, index + 1, prev * cur, 0, value - prev + prev * cur, path);
                    path.RemoveAt(path.Count - 1);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
