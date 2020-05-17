using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.LCCI
{
    class LCCI3_06 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class AnimalShelf
        {
            private readonly Queue<int[]> _dogs = new Queue<int[]>();
            private readonly Queue<int[]> _cats = new Queue<int[]>();

            public AnimalShelf()
            {

            }

            public void Enqueue(int[] animal)
            {
                if (animal[1] == 0)
                {
                    _cats.Enqueue(animal);
                }
                else
                {
                    _dogs.Enqueue(animal);
                }
            }

            public int[] DequeueAny()
            {
                if (_cats.Count == 0)
                {
                    return DequeueDog();
                }
                else if (_dogs.Count == 0)
                {
                    return DequeueCat();
                }
                if (_cats.Peek()[0] < _dogs.Peek()[0])
                {
                    return _cats.Dequeue();
                }
                else
                {
                    return _dogs.Dequeue();
                }
            }

            public int[] DequeueDog()
            {
                if (_dogs.Count > 0)
                {
                    return _dogs.Dequeue();
                }
                return new int[] { -1, -1 };
            }

            public int[] DequeueCat()
            {
                if (_cats.Count > 0)
                {
                    return _cats.Dequeue();
                }
                return new int[] { -1, -1 };
            }
        }
    }
}
