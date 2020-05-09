using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._60
{
    class A972 : IQuestion
    {
        public void Run()
        {
            var ans = new Solution().IsRationalEqual("0.(52)", "0.5(25)");
        }

        public class Solution
        {
            public bool IsRationalEqual(string S, string T)
            {
                var f1 = Analyze(S);
                var f2 = Analyze(T);
                return f1.IsEqual(f2);
            }

            private FenShu Analyze(string s)
            {
                FenShu f = new FenShu(1, 0);
                var temp = s.Split('.', '(', ')');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Length == 0)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        f.Add(new FenShu(1, long.Parse(temp[i])));
                    }
                    else if (i == 1)
                    {
                        f.Add(new FenShu((long)Math.Pow(10, temp[i].Length), long.Parse(temp[i])));
                    }
                    else if (i == 2)
                    {
                        f.Add(new FenShu((long)Math.Pow(10, temp[i - 1].Length) * ((long)Math.Pow(10, temp[i].Length) - 1), long.Parse(temp[i])));
                    }
                }
                return f;
            }
        }

        public class FenShu
        {
            private long _fenMu;
            private long _fenZi;

            public FenShu(long fenMu, long fenZi)
            {
                var g = Gcd(fenZi, fenMu);
                _fenMu = fenMu / g;
                _fenZi = fenZi / g;
            }

            public void Add(FenShu f)
            {
                if (_fenZi == 0)
                {
                    _fenZi = f._fenZi;
                    _fenMu = f._fenMu;
                }
                else
                {
                    var fenMu = _fenMu * f._fenMu;
                    var fenZi = _fenZi * f._fenMu + _fenMu * f._fenZi;
                    var g = Gcd(fenZi, fenMu);
                    _fenZi = fenZi / g;
                    _fenMu = fenMu / g;
                }
            }

            private long Gcd(long x, long y)
            {
                return x == 0 ? y : Gcd(y % x, x);
            }

            public bool IsEqual(FenShu f)
            {
                return _fenMu == f._fenMu && _fenZi == f._fenZi;
            }
        }
    }
}
