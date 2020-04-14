using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A165 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public int CompareVersion(string version1, string version2)
        {
            int p1 = 0;
            int p2 = 0;
            while (p1 < version1.Length || p2 < version2.Length)
            {
                var v1 = GetNextChunk(version1, p1, out p1);
                var v2 = GetNextChunk(version2, p2, out p2);
                if (v1 != v2)
                {
                    return v1.CompareTo(v2);
                }
            }
            return 0;
        }

        private int GetNextChunk(string version, int start, out int end)
        {
            if (start >= version.Length)
            {
                end = start;
                return 0;
            }
            int length = 0;
            for (int i = start; i < version.Length; i++)
            {
                if (version[i] == '.')
                {
                    break;
                }
                length++;
            }
            end = start + length + 1;
            return int.Parse(version.Substring(start, length));
        }
    }
}
