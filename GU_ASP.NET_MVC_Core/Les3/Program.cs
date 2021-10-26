using System;

namespace Les3
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = new FigureFactories().CreateCircle(5);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            figure = new FigureFactories().CreateRectangle(5, 6);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            figure = new FigureFactories().CreateTriangle(3, 4, 5);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            Console.ReadKey();
        }
    }
}
