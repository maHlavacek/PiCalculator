using Calculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.WpfApp.Model
{
    public class Point : IPoint
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
    }
}
