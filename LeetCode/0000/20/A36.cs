using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A36 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //判断一个 9x9 的数独是否有效。只需要根据以下规则，验证已经填入的数字是否有效即可。


        //	数字 1-9 在每一行只能出现一次。
        //	数字 1-9 在每一列只能出现一次。
        //	数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/valid-sudoku
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool IsValidSudoku(char[][] board)
        {
            int rows = board.Length;
            int cols = board[0].Length;
            HashSet<char>[] rowSet = new HashSet<char>[9];
            HashSet<char>[] colSet = new HashSet<char>[9];
            HashSet<char>[] boardSet = new HashSet<char>[9];
            for (int i = 0; i < 9; i++)
            {
                rowSet[i] = new HashSet<char>(9);
                colSet[i] = new HashSet<char>(9);
                boardSet[i] = new HashSet<char>(9);
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (board[row][col] == '.')
                    {
                        continue;
                    }
                    if (!rowSet[row].Add(board[row][col]) || !colSet[col].Add(board[row][col]))
                    {
                        return false;
                    }
                    int i = row / 3 * 3 + col / 3;
                    if (!boardSet[i].Add(board[row][col]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
