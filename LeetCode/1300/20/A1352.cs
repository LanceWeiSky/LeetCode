using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode._1300._20
{
    class A1352 : IQuestion
    {
        public void Run()
        {
            string[] input = File.ReadAllLines(@"");
            Utility.InvokeHelper<ProductOfNumbers>(input);
        }

        public class ProductOfNumbers
        {

            private List<int> _prefixProduct = new List<int> { 1 };

            public ProductOfNumbers()
            {

            }

            public void Add(int num)
            {
                if (num == 0)
                {
                    _prefixProduct = new List<int> { 1 };
                }
                else
                {
                    _prefixProduct.Add(_prefixProduct.Last() * num);
                }
            }

            public int GetProduct(int k)
            {
                if (_prefixProduct.Count <= k)
                {
                    return 0;
                }
                return _prefixProduct.Last() / _prefixProduct[_prefixProduct.Count - 1 - k];
            }
        }

        public class ProductOfNumbers_1
        {

            private readonly List<int> _count0 = new List<int> { 0 };
            private readonly List<int> _prefixProduct = new List<int> { 1 };

            public ProductOfNumbers_1()
            {

            }

            public void Add(int num)
            {
                if (num == 0)
                {
                    _count0.Add(_count0.Last() + 1);
                    _prefixProduct.Add(_prefixProduct.Last());
                }
                else
                {
                    _count0.Add(_count0.Last());
                    _prefixProduct.Add(_prefixProduct.Last() * num);
                }
            }

            public int GetProduct(int k)
            {
                if (_count0.Last() - _count0[_count0.Count - 1 - k] > 0)
                {
                    return 0;
                }
                return _prefixProduct.Last() / _prefixProduct[_prefixProduct.Count - 1 - k];
            }
        }
    }
}
