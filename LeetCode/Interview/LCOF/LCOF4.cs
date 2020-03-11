using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Interview.LCOF
{
    class LCOF4 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //在一个 n * m 的二维数组中，每一行都按照从左到右递增的顺序排序，每一列都按照从上到下递增的顺序排序。请完成一个函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //由于数组有序，不需要遍历所有元素，我们将初始位置设置为右上角，这个位置有个特点，小的数字在左边，大的数字在下面。
        //遍历时与target比较，若target大：则向下移，若target小：则像左移，直到数组越界则代表没找到。由于右上方向是我们来时的方向，数字已经排除，所以不需要往回移动。
        public bool FindNumberIn2DArray(int[][] matrix, int target)
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
            if (target < matrix[0][0] || target > matrix[rows - 1][cols - 1])
            {
                return false;
            }

            int col = cols - 1;
            int row = 0;
            while (row < rows && col >= 0)
            {
                if (target > matrix[row][col])
                {
                    row++;
                }
                else if (target < matrix[row][col])
                {
                    col--;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
