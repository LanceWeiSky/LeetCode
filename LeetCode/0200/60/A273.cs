using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._60
{
    class A273 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Solution
        {
            public String One(int num)
            {
                switch (num)
                {
                    case 1: return "One";
                    case 2: return "Two";
                    case 3: return "Three";
                    case 4: return "Four";
                    case 5: return "Five";
                    case 6: return "Six";
                    case 7: return "Seven";
                    case 8: return "Eight";
                    case 9: return "Nine";
                }
                return "";
            }

            public String TwoLessThan20(int num)
            {
                switch (num)
                {
                    case 10: return "Ten";
                    case 11: return "Eleven";
                    case 12: return "Twelve";
                    case 13: return "Thirteen";
                    case 14: return "Fourteen";
                    case 15: return "Fifteen";
                    case 16: return "Sixteen";
                    case 17: return "Seventeen";
                    case 18: return "Eighteen";
                    case 19: return "Nineteen";
                }
                return "";
            }

            public String Ten(int num)
            {
                switch (num)
                {
                    case 2: return "Twenty";
                    case 3: return "Thirty";
                    case 4: return "Forty";
                    case 5: return "Fifty";
                    case 6: return "Sixty";
                    case 7: return "Seventy";
                    case 8: return "Eighty";
                    case 9: return "Ninety";
                }
                return "";
            }

            public string TwoNum(int num)
            {
                if (num == 0)
                {
                    return "";
                }
                else if (num < 10)
                {
                    return One(num);
                }
                else if (num < 20)
                {
                    return TwoLessThan20(num);
                }
                else
                {
                    var s = Ten(num / 10);
                    if (num % 10 > 0)
                    {
                        s = $"{s} {One(num % 10)}";
                    }
                    return s;
                }
            }

            public string ThreeNum(int num)
            {
                if (num < 100)
                {
                    return TwoNum(num);
                }
                var s = $"{One(num / 100)} Hundred";
                if (num % 100 != 0)
                {
                    s = $"{s} {TwoNum(num % 100)}";
                }
                return s;
            }

            public string NumberToWords(int num)
            {
                if (num == 0)
                    return "Zero";
                string s = "";
                if (num >= 1000000000)
                {
                    s = $"{ThreeNum(num / 1000000000)} Billion";
                    num %= 1000000000;
                }
                if (num >= 1000000)
                {
                    if (s.Length > 0)
                    {
                        s = $"{s} ";
                    }
                    s = $"{s}{ThreeNum(num / 1000000)} Million";
                    num %= 1000000;
                }
                if (num >= 1000)
                {
                    if (s.Length > 0)
                    {
                        s = $"{s} ";
                    }
                    s = $"{s}{ThreeNum(num / 1000)} Thousand";
                    num %= 1000;
                }
                if (num > 0)
                {
                    if (s.Length > 0)
                    {
                        s = $"{s} ";
                    }
                    s = $"{s}{ThreeNum(num)}";
                }
                return s;
            }
        }
    }
}
