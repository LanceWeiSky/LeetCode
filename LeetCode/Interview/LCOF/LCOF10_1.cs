using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF10_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //写一个函数，输入 n ，求斐波那契（Fibonacci）数列的第 n 项。斐波那契数列的定义如下：

        //F(0) = 0,   F(1) = 1
        //F(N) = F(N - 1) + F(N - 2), 其中 N > 1.

        //斐波那契数列由 0 和 1 开始，之后的斐波那契数就是由之前的两数相加而得出。

        //答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/fei-bo-na-qi-shu-lie-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Solution
        {

            private static Dictionary<int, int> _cache = new Dictionary<int, int>{
                {0, 0},
                {1, 1}
            };
            private static int _maxN = 1;

            //非递归写法，cache存储已经计算过的缓存数据，多次调用提高效率
            public int Fib(int n)
            {
                if (n == 0)
                {
                    return 0;
                }
                else if (n == 1)
                {
                    return 1;
                }
                if (n <= _maxN)
                {
                    return _cache[n];
                }

                int n1 = _cache[_maxN - 1];
                int n2 = _cache[_maxN];
                int ans = 0;
                for (int i = _maxN + 1; i <= n; i++)
                {
                    ans = (n1 + n2) % 1000000007;
                    n1 = n2;
                    n2 = ans;
                    _cache[i] = ans;
                }
                _maxN = n;
                return ans;
            }
        }
    }
}
