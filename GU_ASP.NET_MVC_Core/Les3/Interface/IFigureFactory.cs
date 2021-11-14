namespace Les3.Interface
{
    public interface IFigureFactory
    {
        IFigure CreateCircle(double radius);
        IFigure CreateRectangle(double Width, double Height);
        IFigure CreateTriangle(double A, double B, double C);
    }

}
