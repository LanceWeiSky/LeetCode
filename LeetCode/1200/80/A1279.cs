using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode._1200._80
{
    class A1279 : IQuestion
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public class TrafficLight
        {
            private readonly object _locker = new object();
            private bool _isGreen = true;

            public TrafficLight()
            {

            }

            public void CarArrived(
                int carId,         // ID of the car
                int roadId,        // ID of the road the car travels on. Can be 1 (road A) or 2 (road B)
                int direction,     // Direction of the car
                Action turnGreen,  // Use turnGreen() to turn light to green on current road
                Action crossCar    // Use crossCar() to make car cross the intersection
            )
            {
                lock (_locker)
                {
                    if (_isGreen && roadId == 2)
                    {
                        turnGreen();
                        _isGreen = false;
                    }
                    else if (!_isGreen && roadId == 1)
                    {
                        turnGreen();
                        _isGreen = true;
                    }
                    crossCar();
                }
            }
        }
    }
}
