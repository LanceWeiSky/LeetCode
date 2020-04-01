using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A48 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个 n × n 的二维矩阵表示一个图像。

        //将图像顺时针旋转 90 度。

        //说明：

        //你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/rotate-image
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public void Rotate(int[][] matrix)
        {
            int size = matrix.Length;
            for (int i = 0; i < (size + 1) / 2; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[size - 1 - j][i];
                    matrix[size - 1 - j][i] = matrix[size - 1 - i][size - 1 - j];
                    matrix[size - 1 - i][size - 1 - j] = matrix[j][size - 1 - i];
                    matrix[j][size - 1 - i] = temp;
                }
            }
        }

    }
}
