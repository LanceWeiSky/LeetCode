using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A74 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：


        //	每行中的整数从左到右按升序排列。
        //	每行的第一个整数大于前一行的最后一个整数。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/search-a-2d-matrix
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            if (rows == 0)
            {
                return false;
            }
            int cols = matrix[0].Length;
            if (cols == 0)
            {
                return false;
            }

            int l = 0;
            int r = rows * cols - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                int col = mid % cols;
                int row = mid / cols;
                if (matrix[row][col] == target)
                {
                    return true;
                }
                else if (matrix[row][col] < target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return false;
        }
    }
}
