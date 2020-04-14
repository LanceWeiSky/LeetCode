using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LeetCode._0100._20
{
    class A120 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个三角形，找出自顶向下的最小路径和。每一步只能移动到下一行中相邻的结点上。

        //例如，给定三角形：

        //[
        //     [2],
        //    [3,4],
        //   [6,5,7],
        //  [4,1,8,3]
        //]


        //自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。

        //说明：

        //如果你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题，那么你的算法会很加分。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/triangle
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 0)
            {
                return 0;
            }
            int[] dp = triangle.Last().ToArray();
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count - 1; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }
            return dp[0];
        }
    }
}
