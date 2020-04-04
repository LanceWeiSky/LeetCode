using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A84 : IQuestion
    {
        public void Run()
        {
            int[] h = new int[] { 2, 1, 5, 6, 2, 3 };
            var ans = LargestRectangleArea(h);
        }

        //给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
        //求在该柱状图中，能够勾勒出来的矩形的最大面积。

        public int LargestRectangleArea(int[] heights)
        {
            int max = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i <= heights.Length; i++)
            {
                int currentHeight = -1;
                if (i < heights.Length)
                {
                    currentHeight = heights[i];
                }
                while (stack.Count > 1 && heights[stack.Peek()] > currentHeight)
                {
                    var h = heights[stack.Pop()];
                    max = Math.Max(max, h * (i - stack.Peek() - 1));
                }
                stack.Push(i);
            }
            return max;
        }
    }
}
