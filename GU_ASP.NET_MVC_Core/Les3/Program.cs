using System;

namespace Les3
{
    class Program
    {
        static void Main(string[] args)
        {
            var factories = new FigureFactories();
            var figure = factories.CreateCircle(5);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            figure = factories.CreateRectangle(5, 6);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            figure = factories.CreateTriangle(3, 4, 5);
            new WorkerService().CalculateSquare(figure);
            Console.WriteLine(figure.Square);

            Console.ReadKey();
        }
    }
}
