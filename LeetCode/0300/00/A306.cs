using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LeetCode._0300._00
{
    class A306 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public bool IsAdditiveNumber(string num)
            {
                return DFS(num, 0, new List<long>());
            }

            private bool DFS(string num, int start, List<long> path)
            {
                if (start == num.Length)
                {
                    return path.Count > 2;
                }
                
                long value = 0;
                for (int i = start; i < num.Length; i++)
                {
                    if (i > start && value == 0)
                    {
                        return false;
                    }
                    value = value * 10 + num[i] - '0';
                    if (path.Count < 2 || path[path.Count - 2] + path[path.Count - 1] == value)
                    {
                        path.Add(value);
                        if (DFS(num, i + 1, path))
                        {
                            return true;
                        }
                        path.RemoveAt(path.Count - 1);
                    }
                }
                return false;
            }
        }
    }
}
