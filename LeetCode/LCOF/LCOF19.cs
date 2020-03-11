using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF19 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请实现一个函数用来匹配包含'. '和'*'的正则表达式。模式中的字符'.'表示任意一个字符，而'*'表示它前面的字符可以出现任意次（含0次）。
        //在本题中，匹配是指字符串的所有字符匹配整个模式。例如，字符串"aaa"与模式"a.a"和"ab*ac*a"匹配，但与"aa.a"和"ab*a"均不匹配。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/zheng-ze-biao-da-shi-pi-pei-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //动态规划，定义dp[i][j]为s的前i位与p的前j位是否匹配
        //有一下三种情况：
        //1.p[j]是.的情况，因为.可以匹配任何字符，所以只需判断前j位是否匹配，即dp[i + 1][j + 1] = dp[i][j];
        //2.p[j]是*的情况，由于*是否匹配取决于前面的字符，所以判断j-1的情况，此时分为以下情况
        //  a:j-1是.或者p[j-1]==s[i]的情况，dp[i + 1][j - 1]（*匹配了0次）或者dp[i][j + 1]（*匹配多次）匹配
        //  b:认为*匹配了0次
        //3.p[j]与s[i]相等并且dp[i][j]可以匹配，则dp[i + 1][j + 1]可以匹配。

        public class Solution
        {
            public bool IsMatch(string s, string p)
            {
                if (s == null || p == null)
                {
                    return false;
                }
                // if(p.Length == 0)
                // {
                //     return true;
                // }
                bool[][] dp = new bool[s.Length + 1][];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new bool[p.Length + 1];
                }
                //初始化第一行的值
                dp[0][0] = true;
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] == '*')
                    {
                        dp[0][i + 1] = dp[0][i - 1];
                    }
                }
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < p.Length; j++)
                    {
                        if (p[j] == '.')//.代表任意字符，dp[i + 1][j + 1]是否匹配取决于dp[i][j]，即s的前i个字符是否和p的前j个字符匹配
                        {
                            dp[i + 1][j + 1] = dp[i][j];
                        }
                        else if (p[j] == '*')//*取决于前面的字符
                        {
                            if (p[j - 1] == s[i] || p[j - 1] == '.')//s[i]和p[j - 1]匹配，此时有两种情况，1.*匹配了0次，这种情况与else里面相同。2.*匹配了多次，如果s的前i个字符能与p的前j+1个字符匹配，则s的前i+1个字符也能与p的前j+1个字符匹配，相当于*在i的基础上多匹配了一次
                            {
                                dp[i + 1][j + 1] = dp[i + 1][j - 1] || dp[i][j + 1];
                            }
                            else//s[i]和p[j - 1]不匹配，代表*匹配了0次，忽略p[j]和p[j-1]两个字符，此时s的前i+1个字符与p的前j+1个字符是否匹配取决于s的前i+1个字符是否与p的前j-1（j+1-2=j-1）个字符匹配
                            {
                                dp[i + 1][j + 1] = dp[i + 1][j - 1];
                            }
                        }
                        else//既不是.又不是*，p[j]与s[i]相同，并且s的前i个字符和p的前j个字符匹配，s的前i+1个字符才能和p的前j+1个字符匹配
                        {
                            if (dp[i][j] && p[j] == s[i])
                            {
                                dp[i + 1][j + 1] = true;
                            }
                        }
                    }
                }
                return dp[s.Length][p.Length];
            }
        }
    }
}
