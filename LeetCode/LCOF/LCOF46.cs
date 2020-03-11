using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF46 : IQuestion
    {
        public void Run()
        {
            var ans = TranslateNum(25);
        }

        //给定一个数字，我们按照如下规则把它翻译为字符串：0 翻译成 “a” ，1 翻译成 “b”，……，11 翻译成 “l”，……，25 翻译成 “z”。一个数字可能有多个翻译。
        //请编程实现一个函数，用来计算一个数字有多少种不同的翻译方法。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/ba-shu-zi-fan-yi-cheng-zi-fu-chuan-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //动态规划，规定dp[i]为前i位数字翻译方法的数量
        //若str[i-1]是1,或者str[i-1]是2并且str[i]<6，则dp[i + 1] = dp[i]（单位翻译） + dp[i - 1]（双位翻译）;
        //否则，只能单位翻译，即dp[i + 1] = dp[i]

        public int TranslateNum(int num)
        {
            var str = num.ToString();
            int[] dp = new int[str.Length + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] == '1'
                    || str[i - 1] == '2' && str[i] < '6')
                {
                    dp[i + 1] = dp[i] + dp[i - 1];//可能是单位翻译和双位翻译
                }
                else
                {
                    dp[i + 1] = dp[i];//只能单位翻译
                }
            }
            return dp[str.Length];
        }
    }
}
