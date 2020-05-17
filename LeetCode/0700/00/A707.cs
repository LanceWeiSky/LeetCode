using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0700._00
{
    class A707 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class MyLinkedList
        {
            private readonly MyLinkedNode _head = new MyLinkedNode();
            private readonly MyLinkedNode _tail = new MyLinkedNode();
            private int _count = 0;

            /** Initialize your data structure here. */
            public MyLinkedList()
            {
                _head.Next = _tail;
                _tail.Prev = _head;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
            public int Get(int index)
            {
                if (index >= _count || index < 0)
                {
                    return -1;
                }
                var p = GetAtIndex(index);
                return p.Value;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
            public void AddAtHead(int val)
            {
                MyLinkedNode node = new MyLinkedNode { Value = val };
                node.Next = _head.Next;
                node.Prev = _head;
                _head.Next.Prev = node;
                _head.Next = node;
                _count++;
            }

            /** Append a node of value val to the last element of the linked list. */
            public void AddAtTail(int val)
            {
                MyLinkedNode node = new MyLinkedNode { Value = val };
                node.Next = _tail;
                node.Prev = _tail.Prev;
                _tail.Prev.Next = node;
                _tail.Prev = node;
                _count++;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
            public void AddAtIndex(int index, int val)
            {
                if (index <= 0)
                {
                    AddAtHead(val);
                }
                else if (index == _count)
                {
                    AddAtTail(val);
                }
                else if(index < _count)
                {
                    var p = GetAtIndex(index - 1);
                    var p2 = p.Next;
                    MyLinkedNode node = new MyLinkedNode { Value = val };
                    p.Next = node;
                    node.Prev = p;
                    node.Next = p2;
                    p2.Prev = node;
                    _count++;
                }
            }

            private MyLinkedNode GetAtIndex(int index)
            {
                var temp = _count / 2;
                if (index < temp)
                {
                    var p = _head;
                    for (int i = 0; i <= index; i++)
                    {
                        p = p.Next;
                    }
                    return p;
                }
                else
                {
                    index = _count - 1 - index;
                    var p = _tail;
                    for (int i = 0; i <= index; i++)
                    {
                        p = p.Prev;
                    }
                    return p;
                }
            }

            /** Delete the index-th node in the linked list, if the index is valid. */
            public void DeleteAtIndex(int index)
            {
                if (index < 0 || index >= _count)
                {
                    return;
                }
                var p = GetAtIndex(index);
                p.Prev.Next = p.Next;
                p.Next.Prev = p.Prev;
                _count--;
            }

            private class MyLinkedNode
            { 
                public MyLinkedNode Next { get; set; }
                public MyLinkedNode Prev { get; set; }
                public int Value { get; set; }
            }
        }
    }
}
