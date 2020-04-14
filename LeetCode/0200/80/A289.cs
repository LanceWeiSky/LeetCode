using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A289 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //根据 百度百科 ，生命游戏，简称为生命，是英国数学家约翰·何顿·康威在 1970 年发明的细胞自动机。

        //给定一个包含 m × n 个格子的面板，每一个格子都可以看成是一个细胞。每个细胞都具有一个初始状态：1 即为活细胞（live），或 0 即为死细胞（dead）。每个细胞与其八个相邻位置（水平，垂直，对角线）的细胞都遵循以下四条生存定律：


        //	如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡；
        //	如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活；
        //	如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
        //	如果死细胞周围正好有三个活细胞，则该位置死细胞复活；


        //根据当前状态，写一个函数来计算面板上所有细胞的下一个（一次更新后的）状态。下一个状态是通过将上述规则同时应用于当前状态下的每个细胞所形成的，其中细胞的出生和死亡是同时发生的。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/game-of-life
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public void GameOfLife(int[][] board)
        {
            //2:live->dead
            //3:dead->live

            int rows = board.Length;
            int cols = board[0].Length;

            int[] dr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int count = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        var tr = r + dr[i];
                        var tc = c + dc[i];
                        if (tr >= 0 && tr < rows && tc >= 0 && tc < cols)
                        {
                            if (board[tr][tc] == 1 || board[tr][tc] == 2)
                            {
                                count++;
                            }
                        }
                    }
                    if (board[r][c] == 0 && count == 3)
                    {
                        board[r][c] = 3;
                    }
                    else if (board[r][c] == 1 && (count < 2 || count > 3))
                    {
                        board[r][c] = 2;
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    board[r][c] = board[r][c] % 2;
                }
            }
        }
    }
}
