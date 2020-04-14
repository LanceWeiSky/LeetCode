using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A166 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return "0";
            }
            StringBuilder builder = new StringBuilder();
            long n = Math.Abs((long)numerator);
            long d = Math.Abs((long)denominator);
            if ((numerator ^ denominator) < 0)
            {
                builder.Append('-');
            }
            builder.Append(n / d);
            long remain = n % d;
            if (remain == 0)
            {
                return builder.ToString();
            }
            builder.Append('.');
            Dictionary<string, int> cache = new Dictionary<string, int>();
            remain *= 10;
            while (remain > 0)
            {
                var key = $"{remain}/{d}";
                if (cache.TryGetValue(key, out var index))
                {
                    builder.Insert(index, '(');
                    builder.Append(')');
                    break;
                }
                cache[key] = builder.Length;
                builder.Append(remain / d);
                remain = remain % d;
                remain *= 10;
            }
            return builder.ToString();
        }
    }
}
