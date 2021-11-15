namespace Calculator
{
    public class Multiplication : IAction
    {
        public double Result(double x, double y)
        {
            return x * y;
        }
    }
}
