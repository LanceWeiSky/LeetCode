using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A211 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        internal class TierNode
        {
            internal bool IsEnd { get; set; }
            internal TierNode[] Links { get; } = new TierNode[26];

            public void Put(char c)
            {
                Links[c - 'a'] = new TierNode();
            }

            public bool Contains(char c)
            {
                return Links[c - 'a'] != null;
            }

            public TierNode Get(char c)
            {
                return Links[c - 'a'];
            }
        }

        public class WordDictionary
        {
            private TierNode _root = new TierNode();

            /** Initialize your data structure here. */
            public WordDictionary()
            {

            }

            private TierNode GetPrefix(string prefix)
            {
                var node = _root;
                foreach (var c in prefix)
                {
                    if (!node.Contains(c))
                    {
                        node.Put(c);
                    }
                    node = node.Get(c);
                }
                return node;
            }

            /** Adds a word into the data structure. */
            public void AddWord(string word)
            {
                var node = GetPrefix(word);
                node.IsEnd = true;
            }

            /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
            public bool Search(string word)
            {
                return Search(word, 0, _root);
            }

            private bool Search(string word, int index, TierNode node)
            {
                if (node == null)
                {
                    return false;
                }
                if (index == word.Length)
                {
                    return node.IsEnd;
                }
                var c = word[index];
                if (c == '.')
                {
                    foreach (var temp in node.Links)
                    {
                        if (Search(word, index + 1, temp))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    node = node.Get(c);
                }
                return Search(word, index + 1, node);
            }
        }
    }
}
