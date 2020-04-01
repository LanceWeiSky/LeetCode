using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A63 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。

        //机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。

        //现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？

        //网格中的障碍物和空位置分别用 1 和 0 来表示。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/unique-paths-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int rows = obstacleGrid.Length;
            if (rows == 0)
            {
                return 0;
            }
            int cols = obstacleGrid[0].Length;
            if (cols == 0)
            {
                return 0;
            }
            int[] count = new int[cols + 1];
            count[1] = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        count[j + 1] = 0;
                    }
                    else
                    {
                        count[j + 1] += count[j];
                    }
                }
            }
            return count[cols];
        }
    }
}
