using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A91 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //一条包含字母 A-Z 的消息通过以下方式进行了编码：

        //'A' -> 1
        //'B' -> 2
        //...
        //'Z' -> 26


        //给定一个只包含数字的非空字符串，请计算解码方法的总数。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/decode-ways
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int NumDecodings(string s)
        {
            if (s[0] == '0')
            {
                return 0;
            }
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                    {
                        dp[i + 1] = dp[i - 1];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (s[i - 1] == '1' || s[i - 1] == '2' && s[i] < '7')
                {
                    dp[i + 1] = dp[i] + dp[i - 1];
                }
                else
                {
                    dp[i + 1] = dp[i];
                }
            }
            return dp[s.Length];
        }
    }
}
