using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF12 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }


        //请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有字符的路径。
        //路径可以从矩阵中的任意一格开始，每一步可以在矩阵中向左、右、上、下移动一格。
        //如果一条路径经过了矩阵的某一格，那么该路径不能再次进入该格子。
        //例如，在下面的3×4的矩阵中包含一条字符串“bfce”的路径（路径中的字母用加粗标出）。

        //[["a","b","c","e"],
        //["s","f","c","s"],
        //["a","d","e","e"]]

        //但矩阵中不包含字符串“abfb”的路径，因为字符串的第一个字符b占据了矩阵中的第一行第二个格子之后，路径不能再次进入这个格子。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/ju-zhen-zhong-de-lu-jing-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        //思路解析：
        //设置一个临时数组，存储已经走过的格子

        public class Solution
        {
            public bool Exist(char[][] board, string word)
            {
                if (string.IsNullOrEmpty(word))
                {
                    return true;
                }
                int rows = board.Length;
                int cols = board[0].Length;
                bool[][] temp = new bool[rows][];
                for (int i = 0; i < rows; i++)
                {
                    temp[i] = new bool[cols];
                }
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (SearchWord(board, r, c, word, 0, temp, rows, cols))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            private bool SearchWord(char[][] board, int row, int col, string word, int i, bool[][] temp, int rows, int cols)
            {
                if (!temp[row][col] && board[row][col] == word[i])
                {
                    temp[row][col] = true;//当前格子已经走过，置为true
                    if (SearchNext(board, row, col, word, i + 1, temp, rows, cols))
                    {
                        return true;
                    }
                    temp[row][col] = false;//此路不同，置回false
                }
                return false;
            }

            private bool SearchNext(char[][] board, int row, int col, string word, int i, bool[][] temp, int rows, int cols)
            {
                if (i == word.Length)
                {
                    return true;
                }
                if (row > 0)
                {
                    if (SearchWord(board, row - 1, col, word, i, temp, rows, cols))
                    {
                        return true;
                    }
                }
                if (row < rows - 1)
                {
                    if (SearchWord(board, row + 1, col, word, i, temp, rows, cols))
                    {
                        return true;
                    }
                }
                if (col > 0)
                {
                    if (SearchWord(board, row, col - 1, word, i, temp, rows, cols))
                    {
                        return true;
                    }
                }
                if (col < cols - 1)
                {
                    if (SearchWord(board, row, col + 1, word, i, temp, rows, cols))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
