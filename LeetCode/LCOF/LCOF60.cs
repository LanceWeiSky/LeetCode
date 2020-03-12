using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF60 : IQuestion
    {
        public void Run()
        {
            var ans = TwoSum(2);
        }

        //把n个骰子扔在地上，所有骰子朝上一面的点数之和为s。输入n，打印出s的所有可能的值出现的概率。

        //你需要用一个浮点数数组返回答案，其中第 i 个元素代表这 n 个骰子所能掷出的点数集合中第 i 小的那个的概率。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/nge-tou-zi-de-dian-shu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //我们讨论n个骰子和值是m时出现的次数，我们把前n-1个骰子看成一个整体S[n-1]，第n个骰子有6种情况1~6点。
        //当第n个骰子是1点时，S[n-1]=m-1
        //当第n个骰子是2点时，S[n-1]=m-2
        //当第n个骰子是3点时，S[n-1]=m-3
        //当第n个骰子是4点时，S[n-1]=m-4
        //当第n个骰子是5点时，S[n-1]=m-5
        //当第n个骰子是6点时，S[n-1]=m-6
        //所以n个骰子出现m点的次数等于n-1个骰子出现m-1,m-2,m-3,m-4,m-5,m-6点的和，需要注意边界值情况。n个骰子最小值是n,最大值是6*n。

        public double[] TwoSum(int n)
        {
            int[] dp = new int[70];//定义dp[i]为出现i点的次数，初始化1个骰子出现1~6点的次数都为1
            for (int i = 1; i <= 6; i++)
            {
                dp[i] = 1;
            }
            for (int i = 2; i <= n; i++)
            {
                for (int j = 6 * i; j >= i; j--)//由于使用的是一维数组，所以从后向前计算，防止出现值被覆盖的情况
                {
                    dp[j] = 0;
                    for (int k = 1; k <= 6; k++)
                    {
                        if (j - k < i - 1)
                        {
                            break;
                        }
                        dp[j] += dp[j - k];
                    }
                }
            }

            var all = Math.Pow(6, n);
            double[] ans = new double[n * 5 + 1];
            for (int i = n; i <= n * 6; i++)
            {
                ans[i - n] = dp[i] / all;
            }
            return ans;
        }
    }
}
