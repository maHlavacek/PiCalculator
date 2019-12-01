using Calculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.WpfApp.Models
{
    public class Point : IPoint
    {
        public double XCoordinate { get; private set; }
        public double YCoordinate { get; private set; }

        public Point(double x, double y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
    }
}
