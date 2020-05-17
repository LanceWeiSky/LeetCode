using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0400._60
{
    class A468 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public string ValidIPAddress(string IP)
            {
                if (!string.IsNullOrEmpty(IP))
                {
                    if (ValidIPV4(IP))
                    {
                        return "IPv4";
                    }
                    else if (ValidIPV6(IP))
                    {
                        return "IPv6";
                    }
                }
                return "Neither";
            }

            private bool ValidIPV4(string ip)
            {
                var temp = ip.Split('.');
                if (temp.Length != 4)
                {
                    return false;
                }
                foreach (var num in temp)
                {
                    int length = num.Length;
                    if (length == 0 || length > 3)
                    {
                        return false;
                    }
                    if (!int.TryParse(num, out var n) || n < 0 || n > 255 || !n.ToString().Equals(num))
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool ValidIPV6(string ip)
            {
                var temp = ip.Split(':');
                if (temp.Length != 8)
                {
                    return false;
                }
                foreach (var num in temp)
                {
                    if (num.Length == 0 || num.Length > 4)
                    {
                        return false;
                    }
                    foreach (var c in num)
                    {
                        if (!Char.IsDigit(c) && !(c >= 'a' && c <= 'f' || c >= 'A' && c <= 'F'))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
