using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode._0600._40
{
    class A642 : IQuestion
    {
        public void Run()
        {
            var instance = new AutocompleteSystem(new string[] { "i love you", "island", "iroman", "i love leetcode" }, new int[] { 5, 3, 2, 2 });
            for (int i = 0; i < 3; i++)
            {
                var r = instance.Input('i');
                r = instance.Input(' ');
                r = instance.Input('a');
                r = instance.Input('#');
            }
        }

        public class AutocompleteSystem
        {

            private readonly TrieNode _root = new TrieNode();
            private TrieNode _p;
            private StringBuilder _input = new StringBuilder();

            public AutocompleteSystem(string[] sentences, int[] times)
            {
                for (int i = 0; i < sentences.Length; i++)
                {
                    Insert(sentences[i], times[i]);
                }
                _p = _root;
            }

            private void Insert(string sentence, int times)
            {
                var p = _root;
                foreach (var c in sentence)
                {
                    p = p.Insert(c, sentence, times);
                }
                p.Insert('#', sentence, times);
            }

            public IList<string> Input(char c)
            {
                if (c == '#')
                {
                    Insert(_input.ToString(), 1);
                    _input.Clear();
                    _p = _root;
                    return new List<string>();
                }
                _input.Append(c);
                if (_p != null)
                {
                    _p = _p.GetNext(c);
                }
                if (_p == null)
                {
                    return new List<string>();
                }
                return _p.GetMaxSentences();
            }
        }

        internal class TrieNode
        {
            private TrieNode[] _children = new TrieNode[27];
            private Dictionary<string, TrieInfo> _map = new Dictionary<string, TrieInfo>();
            private SortedSet<TrieInfo> _sorted = new SortedSet<TrieInfo>(new TireComparer());

            public TrieNode Insert(char c, string sentence, int times)
            {
                if (_map.TryGetValue(sentence, out var info))
                {
                    _sorted.Remove(info);
                    info.Times += times;
                    _sorted.Add(info);
                }
                else
                {
                    info = new TrieInfo { Sentence = sentence, Times = times };
                    _map.Add(sentence, info);
                    _sorted.Add(info);
                }
                while (_sorted.Count > 3)
                {
                    _sorted.Remove(_sorted.Max);
                }
                if (c == '#')
                {
                    return null;
                }
                return CreateNode(c);
            }

            public TrieNode GetNext(char c)
            {
                if (c == ' ')
                {
                    return _children[26];
                }
                return _children[c - 'a'];
            }

            public TrieNode CreateNode(char c)
            {
                if (c == ' ')
                {
                    if (_children[26] == null)
                    {
                        _children[26] = new TrieNode();
                    }
                    return _children[26];
                }
                else
                {
                    if (_children[c - 'a'] == null)
                    {
                        _children[c - 'a'] = new TrieNode();
                    }
                    return _children[c - 'a'];
                }
            }

            public List<string> GetMaxSentences()
            {
                return _sorted.Select(node => node.Sentence).ToList();
            }
        }

        internal class TrieInfo
        {
            public string Sentence { get; set; }
            public int Times { get; set; }
        }

        internal class TireComparer : IComparer<TrieInfo>
        {
            public int Compare(TrieInfo x, TrieInfo y)
            {
                var c = y.Times.CompareTo(x.Times);
                if (c == 0)
                {
                    c = x.Sentence.CompareTo(y.Sentence);
                }
                return c;
            }
        }

    }
}
