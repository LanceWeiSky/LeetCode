using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._00
{
    class A115 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串 S 和一个字符串 T，计算在 S 的子序列中 T 出现的个数。

        //一个字符串的一个子序列是指，通过删除一些（也可以不删除）字符且不干扰剩余字符相对位置所组成的新字符串。（例如，"ACE" 是 "ABCDE" 的一个子序列，而 "AEC" 不是）

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/distinct-subsequences
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int NumDistinct(string s, string t)
        {
            int[,] dp = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j + 1] + dp[i, j];
                    }
                    else
                    {
                        dp[i + 1, j + 1] = dp[i, j + 1];
                    }
                }
            }
            return dp[s.Length, t.Length];
        }
    }
}
