using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._20
{
    class A127 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        //给定两个单词（beginWord 和 endWord）和一个字典，找到从 beginWord 到 endWord 的最短转换序列的长度。转换需遵循如下规则：


        //	每次转换只能改变一个字母。
        //	转换过程中的中间单词必须是字典中的单词。


        //说明:


        //	如果不存在这样的转换序列，返回 0。
        //	所有单词具有相同的长度。
        //	所有单词只由小写字母组成。
        //	字典中不存在重复的单词。
        //	你可以假设 beginWord 和 endWord 是非空的，且二者不相同。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/word-ladder
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return 0;
            }
            List<string> beginWordList = new List<string>(wordList);
            List<string> endWordList = new List<string>(wordList);
            Queue<string> beginQueue = new Queue<string>();
            Queue<string> endQueue = new Queue<string>();
            beginQueue.Enqueue(beginWord);
            endQueue.Enqueue(endWord);
            HashSet<string> beginVisited = new HashSet<string> { beginWord };
            HashSet<string> endVisited = new HashSet<string> { endWord };

            int ans = 0;
            while (beginQueue.Count > 0 && endQueue.Count > 0)
            {
                if (beginQueue.Count <= endQueue.Count)//top bfs
                {
                    var c = beginQueue.Count;
                    List<int> removeIdx = new List<int>();
                    for (int i = 0; i < c; i++)
                    {
                        var p = beginQueue.Dequeue();
                        for (int j = 0; j < beginWordList.Count; j++)
                        {
                            if (IsNeighbor(p, beginWordList[j]))
                            {
                                if (endVisited.Contains(beginWordList[j]))
                                {
                                    return ans + 2;
                                }
                                beginQueue.Enqueue(beginWordList[j]);
                                beginVisited.Add(beginWordList[j]);
                                removeIdx.Add(j);
                            }
                        }
                    }
                    removeIdx.Sort();
                    int lastRemoveIdx = -1;
                    for (int j = removeIdx.Count - 1; j >= 0; j--)
                    {
                        if (lastRemoveIdx != removeIdx[j])
                        {
                            lastRemoveIdx = removeIdx[j];
                            beginWordList.RemoveAt(lastRemoveIdx);
                        }
                    }
                }
                else//bottom bfs
                {
                    var c = endQueue.Count;
                    List<int> removeIdx = new List<int>();
                    for (int i = 0; i < c; i++)
                    {
                        var p = endQueue.Dequeue();
                        for (int j = 0; j < endWordList.Count; j++)
                        {
                            if (IsNeighbor(p, endWordList[j]))
                            {
                                if (beginVisited.Contains(endWordList[j]))
                                {
                                    return ans + 2;
                                }
                                endQueue.Enqueue(endWordList[j]);
                                endVisited.Add(endWordList[j]);
                                removeIdx.Add(j);
                            }
                        }
                    }
                    removeIdx.Sort();
                    int lastRemoveIdx = -1;
                    for (int j = removeIdx.Count - 1; j >= 0; j--)
                    {
                        if (lastRemoveIdx != removeIdx[j])
                        {
                            lastRemoveIdx = removeIdx[j];
                            endWordList.RemoveAt(lastRemoveIdx);
                        }
                    }
                }
                ans++;
            }
            return 0;
        }

        private bool IsNeighbor(string str1, string str2)
        {
            int distance = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if (distance == 1)
                    {
                        return false;
                    }
                    distance++;
                }
            }
            return distance == 1;
        }
    }
}
