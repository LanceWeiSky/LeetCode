using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF62 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //0,1,,n-1这n个数字排成一个圆圈，从数字0开始，每次从这个圆圈里删除第m个数字。求出这个圆圈里剩下的最后一个数字。

        //例如，0、1、2、3、4这5个数字组成一个圆圈，从数字0开始每次删除第3个数字，则删除的前4个数字依次是2、0、4、1，因此最后剩下的数字是3。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int LastRemaining(int n, int m)
        {
            //约瑟夫环问题
            int ans = 0;
            for (int i = 2; i <= n; i++)
            {
                ans = (ans + m) % i;
            }
            return ans;
        }
    }
}
