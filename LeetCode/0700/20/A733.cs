using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._20
{
    class A733 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
            {
                var originalColor = image[sr][sc];
                if (originalColor == newColor)
                {
                    return image;
                }
                Dfs(image, sr, sc, originalColor, newColor);
                return image;
            }

            private void Dfs(int[][] image, int sr, int sc, int originalColor, int newColor)
            {
                if (image[sr][sc] != originalColor)
                {
                    return;
                }
                image[sr][sc] = newColor;
                if (sr > 0)
                {
                    Dfs(image, sr - 1, sc, originalColor, newColor);
                }
                if (sc > 0)
                {
                    Dfs(image, sr, sc - 1, originalColor, newColor);
                }
                if (sr < image.Length - 1)
                {
                    Dfs(image, sr + 1, sc, originalColor, newColor);
                }
                if (sc < image[0].Length - 1)
                {
                    Dfs(image, sr, sc + 1, originalColor, newColor);
                }
            }
        }
    }
}
