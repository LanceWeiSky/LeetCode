using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LeetCode._0300._00
{
    class A301 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> RemoveInvalidParentheses(string s)
            {
                int leftDelCount = 0;
                int rightDelCount = 0;
                foreach (var c in s)
                {
                    if (c == '(')
                    {
                        leftDelCount++;
                    }
                    else if (c == ')')
                    {
                        if (leftDelCount == 0)
                        {
                            rightDelCount++;
                        }
                        else
                        {
                            leftDelCount--;
                        }
                    }
                }

                HashSet<string> ans = new HashSet<string>();
                Remove(ans, s, 0, 0, leftDelCount, rightDelCount, new List<char>());
                return ans.ToList();
            }

            private void Remove(HashSet<string> ans, string s, int index, int currentLeftCount, int leftRemainCount, int rightRemainCount, List<char> path)
            {
                if (leftRemainCount == 0 && rightRemainCount == 0 || index == s.Length)
                {
                    if (leftRemainCount == 0 && rightRemainCount == 0 && IsValid(currentLeftCount, s, index))
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (var c in path)
                        {
                            builder.Append(c);
                        }
                        builder.Append(s.Substring(index));
                        ans.Add(builder.ToString());
                    }
                    return;
                }

                if (s[index] == '(' && leftRemainCount > 0)
                {
                    Remove(ans, s, index + 1, currentLeftCount, leftRemainCount - 1, rightRemainCount, path);
                }
                else if (s[index] == ')' && rightRemainCount > 0)
                {
                    Remove(ans, s, index + 1, currentLeftCount, leftRemainCount, rightRemainCount - 1, path);
                }
                if (s[index] == '(')
                {
                    currentLeftCount++;
                }
                else if (s[index] == ')')
                {
                    currentLeftCount--;
                }
                if (currentLeftCount >= 0)
                {
                    path.Add(s[index]);
                    Remove(ans, s, index + 1, currentLeftCount, leftRemainCount, rightRemainCount, path);
                    path.RemoveAt(path.Count - 1);
                }
            }

            private bool IsValid(int currentLeftCount, string s, int index)
            {
                for (int i = index; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        currentLeftCount++;
                    }
                    else if (s[i] == ')')
                    {
                        if (currentLeftCount == 0)
                        {
                            return false;
                        }
                        else
                        {
                            currentLeftCount--;
                        }
                    }
                }
                return currentLeftCount == 0;
            }
        }
    }
}
