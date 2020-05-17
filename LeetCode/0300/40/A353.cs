using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._0300._40
{
    class A353 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class SnakeGame
        {
            private readonly Queue<int[]> _queue = new Queue<int[]>();
            private readonly int _width;
            private readonly int _height;
            private int[] _head;
            private readonly int[][] _food;
            private int _foodIndex = 0;
            private readonly Dictionary<string, int[]> _moveMap = new Dictionary<string, int[]>
            {
                { "U", new int[]{ -1, 0 } },
                { "L", new int[]{ 0, -1 } },
                { "R", new int[]{ 0, 1 } },
                { "D", new int[]{ 1, 0 } },
            };
            private int _score = 0;
            private HashSet<long> _body = new HashSet<long>();

            /** Initialize your data structure here.
                @param width - screen width
                @param height - screen height 
                @param food - A list of food positions
                E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
            public SnakeGame(int width, int height, int[][] food)
            {
                _width = width;
                _height = height;
                _food = food;
                _head = new int[] { 0, 0 };
                _queue.Enqueue(_head);
                _body.Add(GetHash(_head));
            }

            /** Moves the snake.
                @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
                @return The game's score after the move. Return -1 if game over. 
                Game over when snake crosses the screen boundary or bites its body. */
            public int Move(string direction)
            {
                var head = GetNewHead(direction);
                if(head == null)
                {
                    return -1;
                }
                _head = head;
                _queue.Enqueue(head);
                if (_foodIndex < _food.Length && _food[_foodIndex][0] == _head[0] && _food[_foodIndex][1] == _head[1])
                {
                    _foodIndex++;
                    _score++;
                    if (!_body.Add(GetHash(_head)))
                    {
                        return -1;
                    }
                }
                else
                {
                    var tail = _queue.Dequeue();
                    _body.Remove(GetHash(tail));
                    if (!_body.Add(GetHash(_head)))
                    {
                        return -1;
                    }
                }

                return _score;
            }

            private int[] GetNewHead(string direction)
            {
                var d = _moveMap[direction];
                var h = new int[] { _head[0] + d[0], _head[1] + d[1] };
                if (h[0] < 0 || h[0] >= _height || h[1] < 0 || h[1] >= _width)
                {
                    return null;
                }
                return h;
            }

            private long GetHash(int[] xy)
            {
                long h = xy[0];
                h <<= 32;
                h |= (long)xy[1];
                return h;
            }
        }
    }
}
