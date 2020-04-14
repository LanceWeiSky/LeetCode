using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A130 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二维的矩阵，包含 'X' 和 'O'（字母 O）。
        //找到所有被 'X' 围绕的区域，并将这些区域里所有的 'O' 用 'X' 填充。

        public void Solve(char[][] board)
        {
            int rows = board.Length;
            if (rows == 0)
            {
                return;
            }
            int cols = board[0].Length;
            if (cols == 0)
            {
                return;
            }
            Queue<Cell> cells = new Queue<Cell>();
            for (int i = 0; i < cols; i++)
            {
                if (board[0][i] == 'O')
                {
                    cells.Enqueue(new Cell { Row = 0, Col = i });
                }
                if (board[rows - 1][i] == 'O')
                {
                    cells.Enqueue(new Cell { Row = rows - 1, Col = i });
                }
            }
            for (int i = 1; i < rows - 1; i++)
            {
                if (board[i][0] == 'O')
                {
                    cells.Enqueue(new Cell { Row = i, Col = 0 });
                }
                if (board[i][cols - 1] == 'O')
                {
                    cells.Enqueue(new Cell { Row = i, Col = cols - 1 });
                }
            }

            int[] dr = new int[] { 0, 1, 0, -1 };
            int[] dc = new int[] { 1, 0, -1, 0 };

            while (cells.Count > 0)
            {
                var c = cells.Dequeue();
                if (board[c.Row][c.Col] == 'O')
                {
                    board[c.Row][c.Col] = '#';
                    for (int i = 0; i < 4; i++)
                    {
                        var row = c.Row + dr[i];
                        var col = c.Col + dc[i];
                        if (row >= 0 && row < rows && col >= 0 && col < cols && board[row][col] == 'O')
                        {
                            cells.Enqueue(new Cell { Row = row, Col = col });
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (board[row][col] == 'O')
                    {
                        board[row][col] = 'X';
                    }
                    else if (board[row][col] == '#')
                    {
                        board[row][col] = 'O';
                    }
                }
            }
        }

        public class Cell
        { 
            public int Col { get; set; }
            public int Row { get; set; }
        }
    }
}
