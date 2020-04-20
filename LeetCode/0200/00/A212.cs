using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LeetCode._0200._00
{
    class A212 : IQuestion
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


        public class Solution
        {
            private readonly TrieNode _root = new TrieNode();
            private int[] _dr = new int[] { 0, 1, 0, -1 };
            private int[] _dc = new int[] { 1, 0, -1, 0 };

            private void Insert(string word)
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

            public IList<string> FindWords(char[][] board, string[] words)
            {
                if (words.Length == 0 || board.Length == 0 || board[0].Length == 0)
                {
                    return new List<string>();
                }

                foreach (var w in words)
                {
                    Insert(w);
                }

                int rows = board.Length;
                int cols = board[0].Length;
                HashSet<string> ans = new HashSet<string>();
                bool[,] used = new bool[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        FindWords(ans, board, used, rows, cols, row, col, new List<char>(), _root);
                        if (ans.Count == words.Length)
                        {
                            return ans.ToList();
                        }
                    }
                }
                return ans.ToList();
            }

            private void FindWords(HashSet<string> ans, char[][] board, bool[,] used, int rows, int cols, int row, int col, List<char> path, TrieNode node)
            { 
                if(used[row, col])
                {
                    return;
                }

                node = node.Get(board[row][col]);
                if (node == null)
                {
                    return;
                }

                used[row, col] = true;
                path.Add(board[row][col]);
                if (node.IsEnd)
                {
                    ans.Add(new string(path.ToArray()));
                }

                for (int i = 0; i < 4; i++)
                {
                    var nr = row + _dr[i];
                    var nc = col + _dc[i];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                    {
                        FindWords(ans, board, used, rows, cols, nr, nc, path, node);
                    }
                }
                path.RemoveAt(path.Count - 1);
                used[row, col] = false;
                
            }
        }
    }
}
