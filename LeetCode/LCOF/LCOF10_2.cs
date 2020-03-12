using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF10_2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //一只青蛙一次可以跳上1级台阶，也可以跳上2级台阶。求该青蛙跳上一个 n 级的台阶总共有多少种跳法。

        //答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/qing-wa-tiao-tai-jie-wen-ti-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //1.当只有一级台阶时，显然只有1种跳法。
        //2.当有两级台阶时，有两种跳法，即：每次跳一级；一次跳两级。
        //3.当有n级台阶时，有两种选择，a.先跳一级，跳法种数为剩下n-1级的跳法种数。b.先跳两级，跳法种数为剩下n-2级跳法种数。即F(n) = F(n - 1) + F(n - 2)

        public int NumWays(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n <= 2)
            {
                return n;
            }

            int n1 = 1;
            int n2 = 2;
            int ans = 0;
            for (int i = 3; i <= n; i++)
            {
                ans = (n1 + n2) % 1000000007;
                n1 = n2;
                n2 = ans;
            }
            return ans;
        }
    }
}
