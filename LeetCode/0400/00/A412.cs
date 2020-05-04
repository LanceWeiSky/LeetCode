using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._00
{
    class A412 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public IList<string> FizzBuzz(int n)
            {
                Dictionary<int, string> map = new Dictionary<int, string>
                {
                    { 3, "Fizz" },
                    { 5, "Buzz" },
                };

                StringBuilder builder = new StringBuilder();
                List<string> ans = new List<string>(n);
                for (int i = 1; i <= n; i++)
                {
                    foreach (var kp in map)
                    {
                        if (i % kp.Key == 0)
                        {
                            builder.Append(kp.Value);
                        }
                    }
                    if (builder.Length == 0)
                    {
                        builder.Append(i.ToString());
                    }
                    ans.Add(builder.ToString());
                    builder.Clear();
                }
                return ans;
            }
        }
    }
}
