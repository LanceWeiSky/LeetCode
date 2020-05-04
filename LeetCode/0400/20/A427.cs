using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LeetCode._0400._20
{
    class A427 : IQuestion
    {
        public void Run()
        {
            var grid = JsonSerializer.Deserialize<int[][]>("[[1,1,0,0],[0,0,1,1],[1,1,0,0],[0,0,1,1]]");
            var ans = new Solution().Construct(grid);
        }

        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }

        public class Solution
        {
            public Node Construct(int[][] grid)
            {
                return Construct(grid, 0, 0, grid.Length);
            }

            private Node Construct(int[][] grid, int row, int col, int length)
            {
                if (length == 1)
                {
                    return new Node(grid[row][col] == 1, true);
                }
                length /= 2;
                var topLeft = Construct(grid, row, col, length);
                var topRight = Construct(grid, row, col + length, length);
                var bottomLeft = Construct(grid, row + length, col, length);
                var bottomRight = Construct(grid, row + length, col + length, length);
                if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf && topLeft.val == topRight.val && topLeft.val == bottomLeft.val && topLeft.val == bottomRight.val)
                {
                    return topLeft;
                }
                return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
            }
        }
    }
}
