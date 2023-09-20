using System.Collections.Generic;
using System;

namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public static implicit operator Point(HashSet<Point> v)
        {
            throw new NotImplementedException();
        }
    }
}