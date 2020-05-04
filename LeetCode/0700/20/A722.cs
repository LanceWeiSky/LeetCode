using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._20
{
    class A722 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> RemoveComments(string[] source)
            {
                List<string> ans = new List<string>(source.Length);
                bool isComment = false;
                string startStr = string.Empty;
                foreach (var s in source)
                {
                    StringBuilder builder = new StringBuilder(s.Length);
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (i < s.Length - 1)
                        {
                            if (!isComment && s[i] == '/')
                            {
                                if (s[i + 1] == '/')
                                {
                                    break;
                                }
                                else if (s[i + 1] == '*')
                                {
                                    isComment = true;
                                    i++;
                                }
                            }
                            else if (isComment && s[i] == '*' && s[i + 1] == '/')
                            {
                                i++;
                                isComment = false;
                                continue;
                            }
                        }
                        if (!isComment)
                        {
                            builder.Append(s[i]);
                        }
                    }
                    if (builder.Length > 0)
                    {
                        if (isComment)
                        {
                            startStr = builder.ToString();
                        }
                        else
                        {
                            ans.Add($"{startStr}{builder.ToString()}");
                            startStr = string.Empty;
                        }
                    }
                    else if(!isComment && startStr.Length > 0)
                    {
                        ans.Add(startStr);
                        startStr = string.Empty;
                    }
                }
                return ans;
            }
        }
    }
}
