using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A72 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个单词 word1 和 word2，计算出将 word1 转换成 word2 所使用的最少操作数 。

        //你可以对一个单词进行如下三种操作：


        //	插入一个字符
        //    删除一个字符

        //    替换一个字符

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/edit-distance
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int MinDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 1; i <= word1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 1; i <= word2.Length; i++)
            {
                dp[0, i] = i;
            }
            for (int i = 0; i < word1.Length; i++)
            {
                for (int j = 0; j < word2.Length; j++)
                {
                    int min = Math.Min(dp[i + 1, j], dp[i, j + 1]) + 1;
                    if (word1[i] == word2[j])
                    {
                        dp[i + 1, j + 1] = Math.Min(min, dp[i, j]);
                    }
                    else
                    {
                        dp[i + 1, j + 1] = Math.Min(min, dp[i, j] + 1);
                    }
                }
            }
            return dp[word1.Length, word2.Length];
        }
    }
}
