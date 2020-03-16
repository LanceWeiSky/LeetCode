using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._00
{
    class A11 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点(i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为(i, ai) 和(i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

        //说明：你不能倾斜容器，且 n 的值至少为 2。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/container-with-most-water
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        //思路解析：
        //双指针，一个从左向右移动，一个从右向左移动，我们在移动指针的时候有两个选择：
        //1.移动较长的指针。
        //2.移动较短的指针。
        //由于容积取决于较短的线，所以移动较长的指针并不能使容积更大，所以我们选择移动较短的指针。

        public int MaxArea(int[] height)
        {
            int l = 0;
            int r = height.Length - 1;
            int max = 0;
            while(l < r)
            {
                if(height[l] > height[r])
                {
                    max = Math.Max((r - l) * height[r], max);
                    r--;
                }
                else
                {
                    max = Math.Max((r - l) * height[l], max);
                    l++;
                }
            }
            return max;
        }

    }
}
