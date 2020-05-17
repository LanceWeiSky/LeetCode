using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI16_02 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class WordsFrequency
        {
            private readonly Dictionary<string, int> _freqs;

            public WordsFrequency(string[] book)
            {
                _freqs = new Dictionary<string, int>(book.Length);
                foreach (var word in book)
                {
                    if (_freqs.TryGetValue(word, out var count))
                    {
                        _freqs[word] = count + 1;
                    }
                    else
                    {
                        _freqs.Add(word, 1);
                    }
                }
            }

            public int Get(string word)
            {
                if (_freqs.TryGetValue(word, out var count))
                {
                    return count;
                }
                return 0;
            }
        }
    }
}
