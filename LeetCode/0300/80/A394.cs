using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._80
{
    class A394 : IQuestion
    {
        public void Run()
        {
            new Solution().DecodeString("3[z]2[2[y]pq4[2[jk]e1[f]]]ef");
        }

        public class Solution
        {
            public string DecodeString(string s)
            {
                if (s.Length < 2)
                {
                    return s;
                }
                StringBuilder ans = new StringBuilder();
                Stack<int> counts = new Stack<int>();
                Stack<string> subStrings = new Stack<string>();
                int num = 0;
                StringBuilder builder = new StringBuilder();
                bool isAppend = true;
                foreach (var c in s)
                {
                    if (c >= '0' && c <= '9')
                    {
                        if (builder.Length > 0)
                        {
                            var str2 = builder.ToString();
                            if (isAppend && subStrings.Count > 0)
                            {
                                str2 = $"{subStrings.Pop()}{str2}";
                            }
                            if (counts.Count == 0)
                            {
                                ans.Append(str2);
                            }
                            else
                            {
                                subStrings.Push(str2);
                            }
                            builder.Clear();
                        }
                        num = num * 10 + c - '0';
                    }
                    else if (c == '[')
                    {
                        if (builder.Length > 0)
                        {
                            var str2 = builder.ToString();
                            if (isAppend && subStrings.Count > 0)
                            {
                                str2 = $"{subStrings.Pop()}{str2}";
                            }
                            if (counts.Count == 0)
                            {
                                ans.Append(str2);
                            }
                            else
                            {
                                subStrings.Push(str2);
                            }
                            builder.Clear();
                        }
                        counts.Push(num);
                        num = 0;
                        isAppend = false;
                    }
                    else if (c == ']')
                    {
                        var count = counts.Pop();
                        StringBuilder builder2 = new StringBuilder();
                        if (isAppend && subStrings.Count > 0)
                        {
                            var str2 = $"{subStrings.Pop()}{builder.ToString()}";
                            for (int i = 0; i < count; i++)
                            {
                                builder2.Append(str2);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                builder2.Append(builder.ToString());
                            }
                        }
                        builder.Clear();
                        string str = builder2.ToString();
                        if (subStrings.Count > 0 && counts.Count == subStrings.Count)
                        {
                            str = $"{subStrings.Pop()}{str}";
                        }
                        if (counts.Count > 0)
                        {
                            subStrings.Push(str);
                        }
                        else
                        {
                            ans.Append(str);
                        }
                        isAppend = true;
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
                if (builder.Length > 0)
                {
                    ans.Append(builder.ToString());
                }
                return ans.ToString();
            }
        }
    }
}
