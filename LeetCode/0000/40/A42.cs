using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._40
{
    class A42 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。

        public int Trap(int[] height)
        {
            //双指针，由于水的多少取决于较短的柱子，所以每次移动短柱子
            int l = 0;
            int r = height.Length - 1;
            int lMax = 0;
            int rMax = 0;
            int ans = 0;
            while (l < r)
            {
                if (height[l] < height[r])
                {
                    if (height[l] < lMax)//柱子短了，可以接水
                    {
                        ans += lMax - height[l];
                    }
                    else//柱子变长了，重新计算
                    {
                        lMax = height[l];
                    }
                    l++;
                }
                else
                {
                    if (height[r] < rMax)
                    {
                        ans += rMax - height[r];
                    }
                    else
                    {
                        rMax = height[r];
                    }
                    r--;
                }
            }
            return ans;
        }
    }
}
