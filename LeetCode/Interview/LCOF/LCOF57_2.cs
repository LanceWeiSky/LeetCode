using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF57_2 : IQuestion
    {
        public void Run()
        {
            var ans = FindContinuousSequence(9);
        }

        //输入一个正整数 target ，输出所有和为 target 的连续正整数序列（至少含有两个数）。

        //序列内的数字由小到大排列，不同序列按照首个数字从小到大排列。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //双指针，一个从1开始，一个从2开始，此时序列的和为最小值。
        //如果和比target小，则扩大范围，即右侧指针向右移一位，如果和比target大，则缩小范围，即左侧指针向右移一位。

        public int[][] FindContinuousSequence(int target)
        {
            List<int[]> ans = new List<int[]>();
            int end = (target + 1) / 2;
            int l = 1;
            int r = 2;
            int sum = 3;
            while (l < r && r <= end)
            {
                if (sum == target)
                {
                    int[] a = new int[r - l + 1];
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = l + i;
                    }
                    ans.Add(a);
                    sum -= l;
                    l++;
                    r++;
                    sum += r;
                }
                else if (sum < target)
                {
                    r++;
                    sum += r;
                }
                else
                {
                    sum -= l;
                    l++;
                }
            }
            return ans.ToArray();
        }

    }
}
