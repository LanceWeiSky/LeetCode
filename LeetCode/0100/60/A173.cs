using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0100._60
{
    class A173 : IQuestion
    {
        public void Run()
        {
            var iterator = new BSTIterator(Utility.ConvertToTreeNode("[7,3,15,null,null,9,20]"));
            iterator.Next();
            iterator.Next();
            iterator.Next();
            iterator.Next();
            iterator.Next();
            iterator.HasNext();
        }

        public class BSTIterator
        {
            private Stack<TreeNode> _stack = new Stack<TreeNode>();
            private TreeNode _prev = null;

            public BSTIterator(TreeNode root)
            {
                while (root != null)
                {
                    _stack.Push(root);
                    root = root.left;
                }
            }

            private void MoveToNext()
            {
                if (_stack.Count == 0)
                {
                    return;
                }
                var cur = _stack.Peek();
                if (cur.right != null && cur.right != _prev)
                {
                    cur = cur.right;
                    while (cur != null)
                    {
                        _stack.Push(cur);
                        cur = cur.left;
                    }
                }
                else
                {
                    _stack.Pop();
                    _prev = cur;
                    while (_stack.Count > 0)
                    {
                        cur = _stack.Peek();
                        if (cur.right == _prev)
                        {
                            _stack.Pop();
                            _prev = cur;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            /** @return the next smallest number */
            public int Next()
            {
                var value = _stack.Peek().val;
                MoveToNext();
                return value;
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return _stack.Count > 0;
            }
        }
    }
}
