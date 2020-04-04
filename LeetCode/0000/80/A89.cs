using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A89 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //格雷编码是一个二进制数字系统，在该系统中，两个连续的数值仅有一个位数的差异。

        //给定一个代表编码总位数的非负整数 n，打印其格雷编码序列。格雷编码序列必须以 0 开头。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/gray-code
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<int> GrayCode(int n)
        {
            List<int> ans = new List<int> { 0 };
            int head = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = ans.Count - 1; j >= 0; j--)
                {
                    ans.Add(ans[j] | head);
                }
                head <<= 1;
            }
            return ans;
        }
    }
}
