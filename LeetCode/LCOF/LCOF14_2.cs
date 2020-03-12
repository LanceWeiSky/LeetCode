using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF14_2 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //给你一根长度为 n 的绳子，请把绳子剪成整数长度的 m 段（m、n都是整数，n>1并且m>1），每段绳子的长度记为 k[0], k[1]...k[m] 。
        //请问 k[0]*k[1]*...*k[m] 可能的最大乘积是多少？例如，当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此时得到的最大乘积是18。

        //答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/jian-sheng-zi-ii-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //与14_1思路相同，唯一不同的是需要考虑int值溢出的问题，我们需要自己写一个求Pow的方法，每次计算1000000007的模

        public class Solution
        {
            public int CuttingRope(int n)
            {
                if (n <= 3)
                {
                    return n - 1;
                }
                var m = n % 3;
                var t = n / 3;
                if (m == 0)
                {
                    return (int)(Pow(3, t) % 1000000007);
                }
                else if (m == 1)
                {
                    return (int)(Pow(3, t - 1) * 4 % 1000000007);
                }
                else
                {
                    return (int)(Pow(3, t) * 2 % 1000000007);
                }
            }

            private long Pow(int x, int n)
            {
                long value = 1;
                for (int i = 0; i < n; i++)
                {
                    value = (value * x) % 1000000007;
                }
                return value;
            }

        }
    }
}
