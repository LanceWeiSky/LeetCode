using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview.LCOF
{
    class LCOF58_1 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //输入一个英文句子，翻转句子中单词的顺序，但单词内字符的顺序不变。为简单起见，标点符号和普通字母一样处理。例如输入字符串"I am a student. "，则输出"student. a am I"。

        //来源：力扣（LeetCode）
        //链接：https://LeetCode-cn.com/problems/fan-zhuan-dan-ci-shun-xu-lcof
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            Stack<string> words = new Stack<string>();
            StringBuilder builder = new StringBuilder();
            foreach (var c in s)
            {
                if (c == ' ')
                {
                    if (builder.Length > 0)
                    {
                        words.Push(builder.ToString());
                        builder.Clear();
                    }
                }
                else
                {
                    builder.Append(c);
                }
            }
            if (builder.Length > 0)
            {
                words.Push(builder.ToString());
                builder.Clear();
            }
            builder.Clear();
            while (words.Count > 0)
            {
                var w = words.Pop();
                builder.Append($"{w} ");
            }
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return builder.ToString();
        }
    }
}
