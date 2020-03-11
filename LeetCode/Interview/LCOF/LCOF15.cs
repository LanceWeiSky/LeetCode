using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF15 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //请实现一个函数，输入一个整数，输出该数二进制表示中 1 的个数。例如，把 9 表示成二进制是 1001，有 2 位是 1。因此，如果输入 9，则该函数输出 2。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/er-jin-zhi-zhong-1de-ge-shu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //n与n-1做按位与运算相当于消掉了最低位的1，计算出直到0位置，我们消掉了多少个1，得到的结果就是1的个数

        public class Solution
        {
            public int HammingWeight(int n)
            {
                int ans = 0;
                while (n != 0)
                {
                    n = n & (n - 1);
                    ans++;
                }
                return ans;
            }
        }
    }
}
