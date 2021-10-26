using Les3.Interface;
using System;

namespace Les3.Figure
{
    internal sealed class Triangle : ITriangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Square { get; private set; }

        public void GqtSquare()
        {
            var p = (A + B + C) / 2;
            Square = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }

}
