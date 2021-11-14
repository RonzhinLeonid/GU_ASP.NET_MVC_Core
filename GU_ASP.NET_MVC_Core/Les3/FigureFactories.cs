using Les3.Figure;
using Les3.Interface;

namespace Les3
{
    public sealed class FigureFactories : IFigureFactory
    {
        public IFigure CreateCircle(double radius)
        {
            return new Circle() { Radius = radius };
        }

        public IFigure CreateRectangle(double width, double height)
        {
            return new Rectangle() { Width = width, Height = height };
        }

        public IFigure CreateTriangle(double a, double b, double c)
        {
            return new Triangle() { A = a, B = b, C = c };
        }
    }

}
