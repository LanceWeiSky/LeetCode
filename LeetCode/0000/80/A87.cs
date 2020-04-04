using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._80
{
    class A87 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串 s1，我们可以把它递归地分割成两个非空子字符串，从而将其表示为二叉树。

        //下图是字符串 s1 = "great" 的一种可能的表示形式。

        //    great
        //   /    \
        //  gr eat
        // / \    /  \
        //g r  e at
        //           / \
        //          a t


        //在扰乱这个字符串的过程中，我们可以挑选任何一个非叶节点，然后交换它的两个子节点。

        //例如，如果我们挑选非叶节点 "gr" ，交换它的两个子节点，将会产生扰乱字符串 "rgeat" 。

        //    rgeat
        //   /    \
        //  rg eat
        // / \    /  \
        //r g  e at
        //           / \
        //          a t


        //我们将 "rgeat” 称作 "great" 的一个扰乱字符串。

        //同样地，如果我们继续交换节点 "eat" 和 "at" 的子节点，将会产生另一个新的扰乱字符串 "rgtae" 。

        //    rgtae
        //   /    \
        //  rg tae
        // / \    /  \
        //r g  ta e
        //       / \
        //      t a


        //我们将 "rgtae” 称作 "great" 的一个扰乱字符串。

        //给出两个长度相等的字符串 s1 和 s2，判断 s2 是否是 s1 的扰乱字符串。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/scramble-string
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


        public bool IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length || s1.Length == 0)
            {
                return false;
            }

            int length = s1.Length;
            bool[,,] dp = new bool[length, length, length + 1];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    dp[i, j, 1] = s1[i] == s2[j];
                }
            }

            for (int l = 2; l <= length; l++)
            {
                for (int i = 0; i <= length - l; i++)
                {
                    for (int j = 0; j <= length - l; j++)
                    {
                        for (int k = 1; k < l; k++)
                        {
                            bool scramble = dp[i, j, k] && dp[i + k, j + k, l - k] || dp[i, j + l - k, k] && dp[i + k, j, l - k];
                            if (scramble)
                            {
                                dp[i, j, l] = true;
                                break;
                            }
                        }
                    }
                }
            }

            return dp[0, 0, length];
        }
    }
}
