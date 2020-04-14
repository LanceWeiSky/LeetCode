using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._0100._20
{
    class A126 : IQuestion
    {
        public void Run()
        {
            var ans = FindLadders("magic", "pearl", new List<string> { "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow", "swear", "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends", "deana", "dried", "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider", "scary", "marks", "perry", "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim", "plugs", "cloak", "cyril", "women", "issue", "rocky", "marry", "trash", "merry", "topic", "hicks", "dicky", "prado", "casio", "lapel", "diane", "serer", "paige", "parry", "elope", "balds", "dated", "copra", "earth", "marty", "slake", "balms", "daryl", "loves", "civet", "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore", "felix", "ogled", "acids", "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse", "joist", "grosz", "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke", "scowl", "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party", "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel", "poole", "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts", "ozark", "umped", "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed", "gelds", "italy", "rakes", "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar", "smith", "tangs", "misty", "wefts", "yawns", "smile", "scuff", "width", "paris", "coded", "sodom", "shits", "benny", "pudgy", "mayer", "peary", "curve", "tulsa", "ramos", "thick", "dogie", "gourd", "strop", "ahmad", "clove", "tract", "calyx", "maris", "wants", "lipid", "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai", "waged", "shari", "magic", "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds", "finks", "twits", "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty", "marta", "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth" });
        }

        //给定两个单词（beginWord 和 endWord）和一个字典 wordList，找出所有从 beginWord 到 endWord 的最短转换序列。转换需遵循如下规则：


        //	每次转换只能改变一个字母。
        //	转换过程中的中间单词必须是字典中的单词。


        //说明:


        //	如果不存在这样的转换序列，返回一个空列表。
        //	所有单词具有相同的长度。
        //	所有单词只由小写字母组成。
        //	字典中不存在重复的单词。
        //	你可以假设 beginWord 和 endWord 是非空的，且二者不相同。

        //来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/word-ladder-ii
        //著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            List<IList<string>> ans = new List<IList<string>>();
            Bfs(ans, beginWord, endWord, wordList);
            return ans;
        }

        private void Bfs(List<IList<string>> ans, string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return;
            }
            List<string> beginWordList = new List<string>(wordList);
            List<string> endWordList = new List<string>(wordList);
            Queue<List<string>> beginQueue = new Queue<List<string>>();
            Queue<List<string>> endQueue = new Queue<List<string>>();
            beginQueue.Enqueue(new List<string> { beginWord });
            endQueue.Enqueue(new List<string> { endWord });
            Dictionary<string, List<List<string>>> beginMap = new Dictionary<string, List<List<string>>> { { beginWord, new List<List<string>> { beginQueue.Peek() } } };
            Dictionary<string, List<List<string>>> endMap = new Dictionary<string, List<List<string>>> { { beginWord, new List<List<string>> { beginQueue.Peek() } } };

            while (beginQueue.Count > 0 && endQueue.Count > 0)
            {
                if (beginQueue.Count <= endQueue.Count)//top bfs
                {
                    var c = beginQueue.Count;
                    bool found = false;
                    beginMap.Clear();
                    List<int> removeIdx = new List<int>();
                    for (int i = 0; i < c; i++)
                    {
                        var p = beginQueue.Dequeue();
                        var curWord = p.Last();
                        for (int j = 0; j < beginWordList.Count; j++)
                        {
                            if (IsNeighbor(curWord, beginWordList[j]))
                            {
                                if (endMap.TryGetValue(beginWordList[j], out var p2))
                                {
                                    found = true;
                                    foreach (var tempP2 in p2)
                                    {
                                        var onePath = new List<string>(p);
                                        for (int k = tempP2.Count - 1; k >= 0; k--)
                                        {
                                            onePath.Add(tempP2[k]);
                                        }
                                        ans.Add(onePath);
                                    }
                                }
                                if (!found)
                                {
                                    var tempPath = new List<string>(p);
                                    tempPath.Add(beginWordList[j]);
                                    beginQueue.Enqueue(tempPath);
                                    if (beginMap.TryGetValue(beginWordList[j], out var map))
                                    {
                                        map.Add(tempPath);
                                    }
                                    else
                                    {
                                        beginMap[beginWordList[j]] = new List<List<string>> { tempPath };
                                    }
                                }
                                removeIdx.Add(j);
                            }
                        }
                    }
                    if (found)
                    {
                        break;
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
                    bool found = false;
                    endMap.Clear();
                    List<int> removeIdx = new List<int>();
                    for (int i = 0; i < c; i++)
                    {
                        var p = endQueue.Dequeue();
                        var curWord = p.Last();
                        for (int j = 0; j < endWordList.Count; j++)
                        {
                            if (IsNeighbor(curWord, endWordList[j]))
                            {
                                if (beginMap.TryGetValue(endWordList[j], out var p2))
                                {
                                    found = true;
                                    foreach (var tempP2 in p2)
                                    {
                                        var onePath = new List<string>(tempP2);
                                        for (int k = p.Count - 1; k >= 0; k--)
                                        {
                                            onePath.Add(p[k]);
                                        }
                                        ans.Add(onePath);
                                    }
                                }
                                if (!found)
                                {
                                    var tempPath = new List<string>(p);
                                    tempPath.Add(endWordList[j]);
                                    endQueue.Enqueue(tempPath);
                                    if (endMap.TryGetValue(endWordList[j], out var map))
                                    {
                                        map.Add(tempPath);
                                    }
                                    else
                                    {
                                        endMap[endWordList[j]] = new List<List<string>> { tempPath };
                                    }
                                }
                                removeIdx.Add(j);
                            }
                        }
                    }
                    if (found)
                    {
                        break;
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
            }
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
