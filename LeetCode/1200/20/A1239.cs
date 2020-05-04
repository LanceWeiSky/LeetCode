using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1200._20
{
    class A1239 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            private int[] _hash;
            private int[] _mask = new int[26];

            public int MaxLength(IList<string> arr)
            {
                _hash = new int[arr.Count];
                for (int i = 0; i < 26; i++)
                {
                    _mask[i] = 1 << i;
                }
                for (int i = 0; i < arr.Count; i++)
                {
                    _hash[i] = GetHash(arr[i]);
                    if (_hash[i] != -1 && arr[i].Length == 26)
                    {
                        return 26;
                    }
                }
                return GetLength(arr, 0, 0);
            }

            private int GetLength(IList<string> arr, int index, int mask)
            {
                if (index == arr.Count)
                {
                    return 0;
                }
                int max = GetLength(arr, index + 1, mask);
                var h = _hash[index];
                if (h != -1 && (mask & h) == 0)
                {
                    max = Math.Max(max, GetLength(arr, index + 1, mask | h) + arr[index].Length);
                }
                return max;
            }

            private int GetHash(string s)
            {
                int mask = 0;
                foreach (var c in s)
                {
                    var m = _mask[c - 'a'];
                    if ((mask & m) == 0)
                    {
                        mask |= m;
                    }
                    else
                    {
                        return -1;
                    }
                }
                return mask;
            }
        }
    }
}
