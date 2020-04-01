using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._20
{
    class A30 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定一个字符串 s 和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
        //注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。

        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> results = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return results;
            }
            int oneLen = words[0].Length;
            int totalLen = oneLen * words.Length;
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!s.Contains(word))
                {
                    return results;
                }
                wordCount.TryGetValue(word, out var v);
                wordCount[word] = v + 1;
            }
            for (int i = 0; i < oneLen; i++)
            {
                int left = i;
                int right = i;
                Dictionary<string, int> subCount = new Dictionary<string, int>();
                int count = 0;
                while (right + oneLen <= s.Length)
                {
                    string temp = s.Substring(right, oneLen);
                    right += oneLen;
                    if (wordCount.ContainsKey(temp))
                    {
                        count++;
                        subCount.TryGetValue(temp, out var v2);
                        subCount[temp] = v2 + 1;
                        while (wordCount[temp] < subCount[temp])
                        {
                            string temp2 = s.Substring(left, oneLen);
                            subCount[temp2]--;
                            count--;
                            left += oneLen;
                        }
                        if (count == words.Length)
                        {
                            results.Add(left);
                        }
                    }
                    else
                    {
                        left = right;
                        count = 0;
                        subCount.Clear();
                    }
                }
            }
            return results;
        }
    }
}
