using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0200._00
{
    class A208 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        internal class TrieNode
        { 
            public bool IsEnd { get; set; }
            public TrieNode[] Links { get; } = new TrieNode[26];

            public void Put(char c, TrieNode node)
            {
                Links[c - 'a'] = node;
            }

            public bool Contains(char c)
            {
                return Links[c - 'a'] != null;
            }

            public TrieNode Get(char c)
            {
                return Links[c - 'a'];
            }
        }

        public class Trie
        {
            private readonly TrieNode _root = new TrieNode();

            /** Initialize your data structure here. */
            public Trie()
            {

            }

            private TrieNode GetPrefix(string prefix)
            {
                TrieNode node = _root;
                foreach (var c in prefix)
                {
                    node = node.Get(c);
                    if (node == null)
                    {
                        return null;
                    }
                }
                return node;
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var node = _root;
                foreach (var c in word)
                {
                    if (!node.Contains(c))
                    {
                        node.Put(c, new TrieNode());
                    }
                    node = node.Get(c);
                }
                node.IsEnd = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var node = GetPrefix(word);
                return node != null && node.IsEnd;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return GetPrefix(prefix) != null;
            }
        }
    }
}
