namespace Calculator
{
    public interface ICalc
    {
        void SetupAction(IAction action);
        double Execute(double x, double y);
    }
}
