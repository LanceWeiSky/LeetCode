using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF14_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //给你一根长度为 n 的绳子，请把绳子剪成整数长度的 m 段（m、n都是整数，n>1并且m>1），每段绳子的长度记为 k[0], k[1]...k[m] 。
        //请问 k[0]*k[1]*...*k[m] 可能的最大乘积是多少？例如，当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此时得到的最大乘积是18。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/jian-sheng-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //我们应该尽量将绳子的长度裁剪为3，这样乘机最大，如果某段长度不足以为3，则至少应该为2.

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
                if (m == 0)//正好可以裁剪为t个长度为3的绳子
                {
                    return (int)Math.Pow(3, t);
                }
                else if (m == 1)//全部按照3裁剪，则剩下一段为1的绳子，所以需要裁剪出t-1个为3的绳子，剩下长度为4的绳子可以裁剪为2*2，也可以不裁剪
                {
                    return (int)Math.Pow(3, t - 1) * 4;
                }
                else//全部按照3裁剪，则剩下一段为2的绳子，符合条件
                {
                    return (int)Math.Pow(3, t) * 2;
                }
            }
        }
    }
}
