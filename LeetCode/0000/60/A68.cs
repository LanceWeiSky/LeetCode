using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0000._60
{
    class A68 : IQuestion
    {
        public void Run()
        {
            string[] words = new string[] { "ask", "not", "what", "your", "country", "can", "do", "for", "you", "ask", "what", "you", "can", "do", "for", "your", "country" };
            var ans = FullJustify(words, 16);
        }

        //给定一个单词数组和一个长度 maxWidth，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。

        //你应该使用“贪心算法”来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。

        //要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。

        //文本的最后一行应为左对齐，且单词之间不插入额外的空格。

        //说明:


        //	单词是指由非空格字符组成的字符序列。
        //	每个单词的长度大于 0，小于等于 maxWidth。

        //    输入单词数组 words 至少包含一个单词。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/text-justification
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> ans = new List<string>();
            int end = -1;
            while (end < words.Length - 1)
            {
                int totalLength = 0;
                int start = end + 1;
                for (int i = start; i < words.Length; i++)
                {
                    totalLength += words[i].Length;
                    if (totalLength > maxWidth)
                    {
                        end = i - 1;
                        totalLength = totalLength - words[i].Length - 1;
                        break;
                    }
                    else if (totalLength == maxWidth || i == words.Length - 1)
                    {
                        end = i;
                        break;
                    }
                    totalLength++;
                }
                if (end == words.Length - 1)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = start; i <= end; i++)
                    {
                        builder.Append(words[i]);
                        if (i != end)
                        {
                            builder.Append(' ');
                        }
                    }
                    if (builder.Length < maxWidth)
                    {
                        builder.Append(' ', maxWidth - builder.Length);
                    }
                    ans.Add(builder.ToString());
                }
                else
                {
                    var spaceCount = maxWidth - totalLength;
                    int wCount = end - start;
                    int additionalSpaceCount = 0;
                    if (wCount > 0)
                    {
                        additionalSpaceCount = spaceCount % wCount;
                        spaceCount = spaceCount / wCount + 1;
                    }
                    StringBuilder builder = new StringBuilder();
                    for (int i = start; i <= end; i++)
                    {
                        builder.Append(words[i]);
                        if (additionalSpaceCount > 0)
                        {
                            builder.Append(' ', spaceCount + 1);
                            additionalSpaceCount--;
                        }
                        else
                        {
                            if (builder.Length < maxWidth)
                            {
                                builder.Append(' ', spaceCount);
                            }
                        }
                    }
                    ans.Add(builder.ToString());
                }
            }
            return ans;
        }
    }
}
