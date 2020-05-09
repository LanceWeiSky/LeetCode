using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._80
{
    class A288 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class ValidWordAbbr
        {
            private readonly HashSet<string> _set;
            private readonly Dictionary<string, int> _abbrs;

            public ValidWordAbbr(string[] dictionary)
            {
                _set = new HashSet<string>(dictionary);
                _abbrs = new Dictionary<string, int>(dictionary.Length);
                foreach (var word in _set)
                {
                    var abbr = GetWordAbbr(word);
                    if (_abbrs.TryGetValue(abbr, out var count))
                    {
                        _abbrs[abbr] = count + 1;
                    }
                    else
                    {
                        _abbrs.Add(abbr, 1);
                    }
                }
            }

            public bool IsUnique(string word)
            {
                if (!_abbrs.TryGetValue(GetWordAbbr(word), out var count))
                {
                    return true;
                }
                if (_set.Contains(word) && count == 1)
                {
                    return true;
                }
                return false;
            }

            private string GetWordAbbr(string word)
            {
                if (word.Length < 3)
                {
                    return word;
                }
                return $"{word[0]}{word.Length - 2}{word[word.Length - 1]}";
            }
        }
    }
}
