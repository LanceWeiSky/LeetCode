using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._1300._40
{
    class A1357 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class Cashier
        {

            private readonly Dictionary<int, double> _productPrices = new Dictionary<int, double>();
            private readonly int _n;
            private readonly int _discount;
            private int _index = 0;

            public Cashier(int n, int discount, int[] products, int[] prices)
            {
                _n = n;
                _discount = discount;
                for (int i = 0; i < products.Length; i++)
                {
                    _productPrices[products[i]] = (double)prices[i];
                }
            }

            public double GetBill(int[] product, int[] amount)
            {
                _index++;
                double bill = 0;
                for(int i = 0; i < product.Length; i++)
                {
                    bill += _productPrices[product[i]] * amount[i];
                }
                if (_index % _n == 0)
                {
                    bill = bill - bill * _discount / 100;
                }
                return bill;
            }
        }
    }
}
