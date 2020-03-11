using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class Heap<T> where T : IComparable
    {
        private readonly List<T> _data;
        private readonly bool _isMax;

        public int Count => _data.Count;

        public Heap(bool isMax)
        {
            _data = new List<T>();
            _isMax = isMax;
        }

        public Heap(IEnumerable<T> data, bool isMax)
        {
            _data = new List<T>(data);
            _isMax = isMax;
            BuildHeap();
        }

        public Heap(int count, bool isMax)
        {
            _data = new List<T>(count);
            _isMax = isMax;
        }

        private void BuildHeap()
        {
            if(_data.Count < 2)
            {
                return;
            }
            var index = GetLastNonLeafIndex(_data.Count);
            for(int i = index; i >= 0; i--)
            {
                ShiftDown(i, _data.Count);
            }
        }

        private void ShiftUp(int index)
        { 
            while(index > 0)
            {
                int parent = (index + 1) / 2 - 1;
                if(_isMax && _data[index].CompareTo(_data[parent]) > 0
                    || !_isMax && _data[index].CompareTo(_data[parent]) < 0)
                {
                    Swap(index, parent);
                    index = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void ShiftDown(int index, int count)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int shiftIndex = index;
            if(left < count)
            {
                if(_isMax && _data[left].CompareTo(_data[shiftIndex]) > 0)
                {
                    shiftIndex = left;
                }
                else if (!_isMax && _data[left].CompareTo(_data[shiftIndex]) < 0)
                {
                    shiftIndex = left;
                }
            }
            if(right < count)
            {
                if (_isMax && _data[right].CompareTo(_data[shiftIndex]) > 0)
                {
                    shiftIndex = right;
                }
                else if (!_isMax && _data[right].CompareTo(_data[shiftIndex]) < 0)
                {
                    shiftIndex = right;
                }
            }
            if(shiftIndex != index)
            {
                Swap(index, shiftIndex);
                ShiftDown(shiftIndex, count);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = _data[i];
            _data[i] = _data[j];
            _data[j] = temp;
        }

        private int GetLastNonLeafIndex(int count)
        {
            return count / 2 - 1;
        }

        public T Pop()
        {
            var item = _data[0];
            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            ShiftDown(0, _data.Count);
            return item;
        }

        public T Peek()
        {
            return _data[0];
        }

        public void Push(T item)
        {
            _data.Add(item);
            ShiftUp(_data.Count - 1);
        }

    }


}
