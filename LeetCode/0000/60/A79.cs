using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A79 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个二维网格和一个单词，找出该单词是否存在于网格中。

        //单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/word-search
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        private int[] dr = new int[] { 0, 1, 0, -1 };
        private int[] dc = new int[] { 1, 0, -1, 0 };

        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (Exist(board, word, rows, cols, r, c, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Exist(char[][] board, string word, int rows, int cols, int row, int col, int index)
        {
            if (board[row][col] != word[index])
            {
                return false;
            }
            if (index == word.Length - 1)
            {
                return true;
            }
            board[row][col] = '\0';
            for (int i = 0; i < 4; i++)
            {
                var r = row + dr[i];
                var c = col + dc[i];
                if (r >= 0 && r < rows && c >= 0 && c < cols && board[r][c] != '\0')
                {
                    if (Exist(board, word, rows, cols, r, c, index + 1))
                    {
                        return true;
                    }
                }
            }
            board[row][col] = word[index];
            return false;
        }
    }
}
