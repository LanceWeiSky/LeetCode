using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A44 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串(s) 和一个字符模式(p) ，实现一个支持 '?' 和 '*' 的通配符匹配。

        //'?' 可以匹配任何单个字符。
        //'*' 可以匹配任意字符串（包括空字符串）。


        //两个字符串完全匹配才算匹配成功。

        //说明:


        //	s 可能为空，且只包含从 a-z 的小写字母。

        //    p 可能为空，且只包含从 a-z 的小写字母，以及字符? 和 *。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/wildcard-matching
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }
            int si = 0;
            int pi = 0;
            int temps = -1;
            int tempp = -1;
            while (si < s.Length)
            {
                if (pi < p.Length && (s[si] == p[pi] || p[pi] == '?'))
                {
                    si++;
                    pi++;
                }
                else if (pi < p.Length && (p[pi] == '*'))
                {
                    temps = si;
                    tempp = pi;
                    pi++;
                }
                else if (temps == -1)
                {
                    return false;
                }
                else
                {
                    si = temps + 1;
                    pi = tempp + 1;
                    temps = si;
                }
            }
            for (int i = pi; i < p.Length; i++)
            {
                if (p[i] != '*')
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsMatch_1(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '*')
                {
                    dp[0, i + 1] = dp[0, i];
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '?' || p[j] == s[i])
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    else if (p[j] == '*')
                    {
                        dp[i + 1, j + 1] = dp[i + 1, j] || dp[i, j + 1];
                    }
                }
            }
            return dp[s.Length, p.Length];
        }
    }
}
