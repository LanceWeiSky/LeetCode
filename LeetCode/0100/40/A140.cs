using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._40
{
    class A140 : IQuestion
    {
        public void Run()
        {
            string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var ans = WordBreak(s, new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
        }

        //给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。

        //说明：


        //	分隔时可以重复使用字典中的单词。
        //	你可以假设字典中没有重复的单词。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/word-break-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<int> length = new HashSet<int>(wordDict.Count);
            HashSet<string> words = new HashSet<string>(wordDict.Count);
            foreach (var w in wordDict)
            {
                length.Add(w.Length);
                words.Add(w);
            }
            var length2 = length.ToList();
            length2.Sort();
            Dictionary<string, List<string>> cache = new Dictionary<string, List<string>>();
            return WordBreak(cache, s, words, length2);
        }

        private List<string> WordBreak(Dictionary<string, List<string>> cache, string s, HashSet<string> words, List<int> length)
        {
            if (cache.TryGetValue(s, out var result))
            {
                return result;
            }
            result = new List<string>();
            foreach (var l in length)
            {
                if (l > s.Length)
                {
                    break;
                }
                string temp = s.Substring(0, l);
                if (words.Contains(temp))
                {
                    string next = s.Substring(l);
                    if (l < s.Length)
                    {
                        var nextResult = WordBreak(cache, next, words, length);
                        foreach (var r in nextResult)
                        {
                            result.Add($"{temp} {r}");
                        }
                    }
                    else
                    {
                        result.Add(temp);
                    }
                }
            }
            cache[s] = result;
            return result;
        }
    }
}
