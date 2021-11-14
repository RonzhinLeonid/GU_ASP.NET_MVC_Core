using Les3.Interface;
using System;

namespace Les3.Figure
{
    internal sealed class Circle : ICircle
    {
        public double Square { get; private set; }
        public double Radius { get; set; }

        public void GqtSquare()
        {
            Square = Math.Pow(Radius, 2) * Math.PI;
        }
    }

}
