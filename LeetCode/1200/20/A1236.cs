using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._20
{
    class A1236 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        class HtmlParser
        {
            public List<String> GetUrls(String url) { throw new NotImplementedException(); }
        }

        class Solution
        {
            public IList<string> Crawl(string startUrl, HtmlParser htmlParser)
            {
                List<string> ans = new List<string>();
                HashSet<string> seen = new HashSet<string> { startUrl };
                Queue<string> queue = new Queue<string>();
                queue.Enqueue(startUrl);
                var hostName = GetHostName(startUrl);
                while (queue.Count > 0)
                {
                    var url = queue.Dequeue();
                    if (url == hostName || url.StartsWith($"{hostName}/"))
                    {
                        ans.Add(url);
                        var nexts = htmlParser.GetUrls(url);
                        foreach (var n in nexts)
                        {
                            if (!seen.Add(n))
                            {
                                continue;
                            }
                            queue.Enqueue(n);
                        }
                    }
                }
                return ans;
            }

            private string GetHostName(string url)
            {
                StringBuilder builder = new StringBuilder("http://");
                for (int i = 7; i < url.Length; i++)
                {
                    if (url[i] == '/')
                    {
                        break;
                    }
                    builder.Append(url[i]);
                }
                return builder.ToString();
            }
        }
    }
}
