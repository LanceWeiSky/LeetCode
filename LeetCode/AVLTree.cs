using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class AVLTree<T> where T : IComparable
    {
        public AVLNode<T> Root { get; private set; }

        public AVLTree()
        { }

        public AVLTree(AVLNode<T> root)
        {
            Root = root;
        }

        public void Insert(T value)
        {
            Root = Insert(Root, value);
        }

        private AVLNode<T> Insert(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return new AVLNode<T>(value);
            }
            var c = value.CompareTo(node.Value);
            if (c > 0)
            {
                node.Right = Insert(node.Right, value);
            }
            else if (c < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                return node;
            }
            return CheckBalance(node);
        }

        public void Delete(T value)
        {
            Root = Delete(Root, value);
        }

        private AVLNode<T> Delete(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            var c = value.CompareTo(node.Value);
            if (c > 0)
            {
                node.Right = Delete(node.Right, value);
            }
            else if (c < 0)
            {
                node.Left = Delete(node.Left, value);
            }
            else
            {
                if (node.Left != null && node.Right != null)
                {
                    if (node.Left.Height < node.Right.Height)
                    {
                        node.Value = FindMin(node.Right);
                        node.Right = Delete(node.Right, node.Value);
                    }
                    else
                    {
                        node.Value = FindMax(node.Left);
                        node.Left = Delete(node.Left, node.Value);
                    }
                }
                else
                {
                    if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
            return CheckBalance(node);
        }

        private T FindMin(AVLNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Value;
        }

        private T FindMax(AVLNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.Value;
        }

        private AVLNode<T> CheckBalance(AVLNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            var diff = HeightDiffLR(node);
            if (Math.Abs(diff) < 2)
            {
                UpdateHeight(node);
            }
            else if (diff == 2)
            {
                if (HeightDiffLR(node.Left) == -1)
                {
                    node.Left = RotateR2L(node.Left);
                }
                node = RotateL2R(node);
            }
            else if (diff == -2)
            {
                if (HeightDiffLR(node.Right) == 1)
                {
                    node.Right = RotateL2R(node.Right);
                }
                node = RotateR2L(node);
            }
            return node;
        }

        private int HeightDiffLR(AVLNode<T> node)
        {
            if (node.Left != null && node.Right != null)
            {
                return node.Left.Height - node.Right.Height;
            }
            else if (node.Left != null)
            {
                return node.Left.Height + 1;
            }
            else if (node.Right != null)
            {
                return -node.Right.Height - 1;
            }
            else
            {
                return 0;
            }
        }

        private AVLNode<T> RotateL2R(AVLNode<T> node)
        {
            var left = node.Left;
            var temp = left.Right;
            left.Right = node;
            node.Left = temp;
            UpdateHeight(node);
            UpdateHeight(left);
            return left;
        }

        private AVLNode<T> RotateR2L(AVLNode<T> node)
        {
            var right = node.Right;
            var temp = right.Left;
            right.Left = node;
            node.Right = temp;
            UpdateHeight(node);
            UpdateHeight(right);
            return right;
        }

        private void UpdateHeight(AVLNode<T> node)
        {
            if (node.Left != null && node.Right != null)
            {
                node.Height = Math.Max(node.Left.Height, node.Right.Height) + 1;
            }
            else if (node.Left != null)
            {
                node.Height = node.Left.Height + 1;
            }
            else if (node.Right != null)
            {
                node.Height = node.Right.Height + 1;
            }
            else
            {
                node.Height = 0;
            }
        }
    }

    public class AVLNode<T> where T : IComparable
    {
        public AVLNode<T> Left { get; internal set; }
        public AVLNode<T> Right { get; internal set; }
        public int Height { get; internal set; }
        public T Value { get; internal set; }

        public AVLNode(T value)
        {
            Value = value;
        }
    }
}
