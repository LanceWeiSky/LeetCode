using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A60 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给出集合[1, 2, 3,…, n]，其所有元素共有 n! 种排列。

        //按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：


        //	"123"
        //	"132"
        //	"213"
        //	"231"
        //	"312"
        //	"321"


        //给定 n 和 k，返回第 k 个排列。

        //说明：


        //	给定 n 的范围是[1, 9]。
        //	给定 k 的范围是[1, n!]。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/permutation-sequence
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public string GetPermutation(int n, int k)
        {
            if (n == 1)
            {
                return "1";
            }
            int[] f = new int[n];
            f[0] = 1;
            f[1] = 1;
            List<int> nums = new List<int>(n);
            nums.Add(1);
            nums.Add(2);
            for (int i = 2; i < f.Length; i++)
            {
                f[i] = f[i - 1] * i;
                nums.Add(i + 1);
            }
            k--;
            StringBuilder builder = new StringBuilder(n);
            for (int i = n - 1; i >= 0; i--)
            {
                var index = k / f[i];
                k = k % f[i];

                builder.Append(nums[index]);
                nums.RemoveAt(index);
            }
            return builder.ToString();
        }
    }
}
