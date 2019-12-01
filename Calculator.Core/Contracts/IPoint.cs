using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Core.Contracts
{
    public interface IPoint
    {
        public double XCoordinate { get; }
        public double YCoordinate { get; }
    }
}
