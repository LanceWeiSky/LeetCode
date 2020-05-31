using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0900._20
{
    class A934 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private int[] dr = new int[] { 1, 0, -1, 0 };
            private int[] dc = new int[] { 0, 1, 0, -1 };

            public int ShortestBridge(int[][] A)
            {
                int rows = A.Length;
                if (rows == 0)
                {
                    return 0;
                }
                int cols = A[0].Length;
                if (cols == 0)
                {
                    return 0;
                }
                var colors = GetColors(A, rows, cols);
                Queue<int[]> queue = new Queue<int[]>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (colors[row, col] == 1)
                        {
                            queue.Enqueue(new int[] { row, col });
                        }
                    }
                }
                int length = 0;
                while (queue.Count > 0)
                {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var temp = queue.Dequeue();
                        for (int j = 0; j < 4; j++)
                        {
                            var row = temp[0] + dr[j];
                            var col = temp[1] + dc[j];
                            if (row >= 0 && row < rows && col >= 0 && col < cols)
                            {
                                if (colors[row, col] == 0)
                                {
                                    colors[row, col] = 1;
                                    queue.Enqueue(new int[] { row, col });
                                }
                                else if (colors[row, col] == 2)
                                {
                                    return length;
                                }
                            }
                        }
                    }
                    length++;
                }
                return -1;
            }

            private int[,] GetColors(int[][] A, int rows, int cols)
            {
                int[,] colors = new int[rows, cols];
                int color = 1;
                Stack<int[]> stack = new Stack<int[]>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (A[row][col] == 1 && colors[row, col] == 0)
                        {
                            stack.Push(new int[] { row, col });
                            colors[row, col] = color;
                            while (stack.Count > 0)
                            {
                                var temp = stack.Pop();
                                for (int i = 0; i < 4; i++)
                                {
                                    var tempRow = temp[0] + dr[i];
                                    var tempCol = temp[1] + dc[i];
                                    if (tempRow >= 0 && tempRow < rows && tempCol >= 0 && tempCol < cols && colors[tempRow, tempCol] == 0 && A[tempRow][tempCol] == 1)
                                    {
                                        colors[tempRow, tempCol] = color;
                                        stack.Push(new int[] { tempRow, tempCol });
                                    }
                                }
                            }
                            color++;
                        }
                    }
                }
                return colors;
            }
        }
    }
}
