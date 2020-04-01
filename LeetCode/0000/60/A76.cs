using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A76 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给你一个字符串 S、一个字符串 T，请在字符串 S 里面找出：包含 T 所有字母的最小子串。

        //示例：

        //输入: S = "ADOBECODEBANC", T = "ABC"
        //输出: "BANC"

        //说明：


        //	如果 S 中不存这样的子串，则返回空字符串 ""。
        //	如果 S 中存在这样的子串，我们保证它是唯一的答案。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/minimum-window-substring
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> tCount = new Dictionary<char, int>(t.Length);
            foreach (var c in t)
            {
                tCount.TryGetValue(c, out var v);
                tCount[c] = v + 1;
            }

            List<KeyValuePair<char, int>> filteredS = new List<KeyValuePair<char, int>>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (tCount.ContainsKey(s[i]))
                {
                    filteredS.Add(new KeyValuePair<char, int>(s[i], i));
                }
            }

            Dictionary<char, int> mCount = new Dictionary<char, int>(filteredS.Count);
            int l = 0;
            int r = 0;
            int count = 0;
            int length = -1;
            int start = -1;
            while (r < filteredS.Count)
            {
                var f = filteredS[r];
                mCount.TryGetValue(f.Key, out var temp);
                temp++;
                mCount[f.Key] = temp;
                if (temp == tCount[f.Key])
                {
                    count++;
                }
                while (count == tCount.Count)
                {
                    var f2 = filteredS[l];
                    var tempLength = f.Value - f2.Value + 1;
                    if (length == -1 || tempLength < length)
                    {
                        start = f2.Value;
                        length = tempLength;
                    }
                    mCount[f2.Key]--;
                    if (mCount[f2.Key] < tCount[f2.Key])
                    {
                        count--;
                    }
                    l++;
                }
                r++;
            }
            if (length >= 0)
            {
                return s.Substring(start, length);
            }
            return string.Empty;
        }
    }
}
