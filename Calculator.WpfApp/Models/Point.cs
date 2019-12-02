using Calculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.WpfApp.Models
{
    public class Point : IPoint
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public Point(double x, double y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public Point()
        {
        }
    }
}
