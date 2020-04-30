using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A399 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private Dictionary<string, string> _parent = new Dictionary<string, string>();
            private Dictionary<string, double> _weight = new Dictionary<string, double>();

            private (string, double) Find(string s)
            {
                string p = null;
                double w = 1;
                while (_parent.TryGetValue(s, out p) && p != s)
                {
                    w *= _weight[s];
                    s = p;
                }
                return (p, w);
            }

            private void Union(string a, string b, double a_b)
            {
                (var p1, var w1) = Find(a);//a/p1 = w1
                (var p2, var w2) = Find(b);//b/p2 = w2
                if (p1 == null)
                {
                    p1 = a;
                    _parent[a] = a;
                    _weight[a] = w1;
                }
                if (p2 == null)
                {
                    p2 = b;
                    _parent[b] = b;
                    _weight[b] = w2;
                }
                if (p1 != p2)
                {
                    _parent[p1] = p2;
                    _weight[p1] = a_b * w2 / w1;//p1/p2 = (a/w1)/(b/w2) = a/b * w2 / w1
                }
            }

            public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Union(equations[i][0], equations[i][1], values[i]);
                }
                double[] ans = new double[queries.Count];
                for (int i = 0; i < queries.Count; i++)
                { 
                    (var p1, var w1) = Find(queries[i][0]);
                    (var p2, var w2) = Find(queries[i][1]);
                    if (p1 == null || p2 == null || p1 != p2)
                    {
                        ans[i] = -1d;
                    }
                    else
                    {
                        ans[i] = w1 / w2;
                    }
                }
                return ans;
            }
        }
    }
}
