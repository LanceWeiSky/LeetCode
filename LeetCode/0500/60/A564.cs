using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0500._60
{
    class A564 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string NearestPalindromic(string n)
            {
                if (n == "0")
                {
                    return "1";
                }
                if (n.Length == 1)
                {
                    return ((char)(n[0] - 1)).ToString();
                }
                var chars = n.ToArray();
                var a = Palindromic(chars);
                int mid = (n.Length - 1) / 2;
                while (mid >= 0 && chars[mid] == '0')
                {
                    chars[mid--] = '9';
                }
                if (mid == 0 && chars[mid] == '1')
                {
                    chars = chars.Skip(1).ToArray();
                    if ((chars.Length & 1) == 1)
                    {
                        chars[chars.Length / 2] = '9';
                    }
                }
                else
                {
                    chars[mid]--;
                }
                var b = Palindromic(chars);

                chars = n.ToArray();
                mid = (n.Length - 1) / 2;
                while (mid >= 0 && chars[mid] == '9')
                {
                    chars[mid--] = '0';
                }
                if (mid < 0)
                {
                    var chars2 = new char[chars.Length + 1];
                    chars2[0] = '1';
                    Array.Copy(chars, 0, chars2, 1, chars.Length);
                    chars = chars2;
                }
                else
                {
                    chars[mid]++;
                }
                var c = Palindromic(chars);
                var sn = long.Parse(n);
                var diff1 = Math.Abs(long.Parse(a) - sn);
                if (diff1 == 0)
                {
                    diff1 = long.MaxValue;
                }
                var diff2 = Math.Abs(long.Parse(b) - sn);
                var diff3 = Math.Abs(long.Parse(c) - sn);
                var min = Math.Min(diff1, Math.Min(diff2, diff3));
                if (min == diff2)
                {
                    return b;
                }
                else if (min == diff1)
                {
                    return a;
                }
                return c;
            }

            private string Palindromic(char[] chars)
            {
                if (chars.Length == 1)
                {
                    return new string(chars);
                }
                StringBuilder builder = new StringBuilder(chars.Length);
                int mid = chars.Length / 2;
                for (int i = 0; i < mid; i++)
                {
                    builder.Append(chars[i]);
                }
                if ((chars.Length & 1) == 1)
                {
                    builder.Append(chars[mid]);
                }
                for (int i = mid - 1; i >= 0; i--)
                {
                    builder.Append(chars[i]);
                }
                return builder.ToString();
            }
        }
    }
}
