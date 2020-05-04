using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._20
{
    class A636 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[] ExclusiveTime(int n, IList<string> logs)
            {
                int[] ans = new int[n];
                Stack<int[]> stack = new Stack<int[]>();
                int prevEndTime = -1;
                foreach (var log in logs)
                {
                    (var id, var start, var time) = ConvertLog(log);
                    if (start)
                    {
                        if (stack.Count > 0)
                        {
                            var prev = stack.Peek();
                            if (prevEndTime == -1)
                            {
                                ans[prev[0]] += time - prev[1];
                            }
                            else
                            {
                                ans[prev[0]] += time - prevEndTime - 1;
                            }
                        }
                        stack.Push(new int[] { id, time });
                        prevEndTime = -1;
                    }
                    else
                    {
                        var prev = stack.Pop();
                        if (prevEndTime == -1)
                        {
                            ans[id] += time - prev[1] + 1;
                        }
                        else
                        {
                            ans[id] += time - prevEndTime;
                        }
                        prevEndTime = time;
                    }
                }
                return ans;
            }

            private (int, bool, int) ConvertLog(string log)
            {
                var split = log.Split(':');
                return (int.Parse(split[0]), split[1] == "start", int.Parse(split[2]));
            }
        }
    }
}
