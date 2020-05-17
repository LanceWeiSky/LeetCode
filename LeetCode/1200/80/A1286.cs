using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._80
{
    class A1286 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class CombinationIterator
        {
            private readonly int[] _pos;
            private readonly string _characters;
            private bool _isFinished;

            public CombinationIterator(string characters, int combinationLength)
            {
                _characters = characters;
                _pos = new int[combinationLength];
                if (combinationLength > characters.Length)
                {
                    _isFinished = true;
                }
                else
                {
                    for (int i = 0; i < combinationLength; i++)
                    {
                        _pos[i] = i;
                    }
                }
            }

            public string Next()
            {
                if (_isFinished)
                {
                    return null;
                }
                StringBuilder builder = new StringBuilder();
                foreach (var p in _pos)
                {
                    builder.Append(_characters[p]);
                }

                int index = -1;
                for (int i = _pos.Length - 1; i >= 0; i--)
                {
                    if (_pos[i] != _characters.Length - _pos.Length + i)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                {
                    _isFinished = true;
                }
                else
                {
                    _pos[index]++;
                    for (int i = index + 1; i < _pos.Length; i++)
                    {
                        _pos[i] = _pos[i - 1] + 1;
                    }
                }
                return builder.ToString();
            }

            public bool HasNext()
            {
                return !_isFinished;
            }
        }
    }
}
