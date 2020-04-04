using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A85 : IQuestion
    {
        public void Run()
        {
            
        }

        //给定一个仅包含 0 和 1 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。

        public int MaximalRectangle(char[][] matrix)
        {
            int rows = matrix.Length;
            if(rows == 0)
            {
                return 0;
            }
            int cols = matrix[0].Length;
            if(cols == 0)
            {
                return 0;
            }

            int max = 0;
            int[] heights = new int[cols + 1];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == '0')
                    {
                        heights[c] = 0;
                    }
                    else
                    {
                        heights[c]++;
                    }
                }
                max = Math.Max(max, MaxRect(heights));
            }
            return max;
        }

        private int MaxRect(int[] nums)
        {
            int max = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 1 && nums[stack.Peek()] > nums[i])
                {
                    var h = nums[stack.Pop()];
                    max = Math.Max(max, h * (i - stack.Peek() - 1));
                }
                stack.Push(i);
            }
            return max;
        }

    }


}
