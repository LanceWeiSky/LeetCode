using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0500._20
{
    class A535 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Codec
        {
            private const string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            private readonly Random _rnd = new Random();
            private readonly Dictionary<string, string> _map = new Dictionary<string, string>();
            private const int SIZE = 6;

            private string GetEncodeString()
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < SIZE; i++)
                {
                    builder.Append(CHARS[_rnd.Next(62)]);
                }
                return builder.ToString();
            }

            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                var url = GetEncodeString();
                while (_map.ContainsKey(url))
                {
                    url = GetEncodeString();
                }
                _map.Add(url, longUrl);
                return $"http://tinyurl.com/{url}";
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                var url = shortUrl.Replace("http://tinyurl.com/", "");
                if (_map.TryGetValue(url, out var longUrl))
                {
                    return longUrl;
                }
                return shortUrl;
            }
        }
    }
}
