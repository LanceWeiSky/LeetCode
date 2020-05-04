using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._20
{
    class A420 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public int StrongPasswordChecker(string s)
            {
                int missDigit = 1, missLower = 1, missUpper = 1;
                int[] modCount = new int[3];
                int totalModifiedCount = 0;
                int i = 0;
                while (i < s.Length)
                {
                    var c = s[i];
                    if (c >= '0' && c <= '9')
                    {
                        missDigit = 0;
                    }
                    else if (c >= 'a' && c <= 'z')
                    {
                        missLower = 0;
                    }
                    else if (c >= 'A' && c <= 'Z')
                    {
                        missUpper = 0;
                    }

                    int length = 1;
                    while (++i < s.Length - 1 && s[i] == c)
                    {
                        length++;
                    }
                    if (length > 2)
                    {
                        modCount[length % 3]++;
                        totalModifiedCount += length / 3;
                    }
                }

                int typeMissCount = missDigit + missLower + missUpper;
                if (s.Length < 6)
                {
                    return Math.Max(typeMissCount, 6 - s.Length);
                }

                if (s.Length <= 20)
                {
                    return Math.Max(typeMissCount, totalModifiedCount);
                }

                int removeLength = s.Length - 20;
                if (removeLength <= modCount[0])
                {
                    return Math.Max(typeMissCount, totalModifiedCount - removeLength) + s.Length - 20;
                }

                removeLength -= modCount[0];
                totalModifiedCount -= modCount[0];
                if (removeLength <= modCount[1] * 2)
                {
                    return Math.Max(typeMissCount, totalModifiedCount - removeLength / 2) + s.Length - 20;
                }

                removeLength -= modCount[1] * 2;
                totalModifiedCount -= modCount[1];
                return Math.Max(typeMissCount, totalModifiedCount - removeLength / 3) + s.Length - 20;
            }
        }
    }
}
