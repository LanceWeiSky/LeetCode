using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._20
{
    class A139 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，判定 s 是否可以被空格拆分为一个或多个在字典中出现的单词。

        //说明：


        //	拆分时可以重复使用字典中的单词。
        //	你可以假设字典中没有重复的单词。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/word-break
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> words = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (dp[j] && words.Contains(s.Substring(j, i + 1 - j)))
                    {
                        dp[i + 1] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
