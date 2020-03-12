using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF66 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个数组 A[0, 1,…, n - 1]，请构建一个数组 B[0, 1,…, n - 1]，其中 B 中的元素 B[i] = A[0]×A[1]×…×A[i - 1]×A[i + 1]×…×A[n - 1]。不能使用除法。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/gou-jian-cheng-ji-shu-zu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //从左到右计算一次乘法累积结果，再从右到左计算一次乘法累积结果，两次结果相乘
        //第一次计算：
        //B[0] = 1
        //B[1] = A[0] = B[0]*A[0]
        //B[2] = A[0]*A[1] = (A[0])*A[1] = B[1]*A[1]
        //B[3] = A[0]*A[1]*A[2] = (A[0]*A[1])*A[2] = B[2]*A[2]
        //B[i] = A[0]*...*A[i-2]*A[i-1] = (A[0]*...*A[i-2])*A[i-1] = B[i-1]*A[i-1]
        //第二次计算：
        //B[n-1] = 1
        //B[n-2] = A[n-1] = A[n-1]*B[n-1]
        //B[n-3] = A[n-1]*A[n-2] = (A[n-1])*A[n-2] = B[n-2]*A[n-2]
        //B[n-4] = A[n-1]*A[n-2]*A[n-3] = (A[n-1]*A[n-2])*A[n-3] = B[n-3]*A[n-3]
        //B[i] = A[n-1]*...*A[i+2]*A[i+1] = (A[n-1]*...*A[i+2])*A[i+1] = B[i+1]*A[i+1]
        //两次相乘：
        //B[i] = A[0]*...*A[i-2]*A[i-1](第一次计算的结果) * A[n-1]*...*A[i+2]*A[i+1](第二次计算的结果)

        public int[] ConstructArr(int[] a)
        {
            if (a.Length == 0)
            {
                return new int[0];
            }
            int[] b = new int[a.Length];
            if (a.Length < 2)
            {
                return b;
            }
            b[0] = 1;
            for (int i = 1; i < a.Length; i++)
            {
                b[i] = b[i - 1] * a[i - 1];
            }
            int m = 1;
            for (int i = a.Length - 2; i >= 0; i--)
            {
                m *= a[i + 1];
                b[i] = b[i] * m;
            }
            return b;
        }
    }
}
