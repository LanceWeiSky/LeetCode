using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF11 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。输入一个递增排序的数组的一个旋转，输出旋转数组的最小元素。例如，数组[3, 4, 5, 1, 2] 为[1, 2, 3, 4, 5] 的一个旋转，该数组的最小值为1。  

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public class Solution
        {
            //遍历找到第一个比左边小的数字
            public int MinArray(int[] numbers)
            {
                int min = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] < min)
                    {
                        return numbers[i];
                    }
                }
                return min;
            }
            //二分法查找
            public int MinArray_1(int[] numbers)
            {
                int i = 0;
                int j = numbers.Length - 1;
                while (i < j)
                {
                    int m = (i + j) / 2;
                    if (numbers[m] < numbers[j])
                    {
                        j = m;
                    }
                    else if (numbers[m] > numbers[j])
                    {
                        i = m + 1;
                    }
                    else
                    {
                        j--;
                    }
                }
                return numbers[i];
            }
        }
    }
}
