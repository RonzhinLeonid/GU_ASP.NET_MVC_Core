namespace Calculator
{
    public class Subtraction : IAction
    {
        public double Result(double x, double y)
        {
            return x - y;
        }
    }
}
