using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0600._00
{
    class A604 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class StringIterator
        {
            private readonly string _str;
            private int _count;
            private int _index;
            private char _char;

            public StringIterator(string compressedString)
            {
                _str = compressedString;
            }

            public char Next()
            {
                if (!HasNext())
                {
                    return ' ';
                }
                if (_count == 0)
                {
                    _char = _str[_index++];
                    while(_index < _str.Length && Char.IsDigit(_str[_index]))
                    {
                        _count = _count * 10 + _str[_index] - '0';
                        _index++;
                    }
                }
                _count--;
                return _char;
            }

            public bool HasNext()
            {
                return _count > 0 || _index < _str.Length;
            }
        }
    }
}
