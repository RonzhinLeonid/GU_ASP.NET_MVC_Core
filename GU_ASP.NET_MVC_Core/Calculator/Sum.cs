namespace Calculator
{
    public class Sum : IAction
    {
        public double Result(double x, double y)
        {
            return x + y;
        }
    }
}
