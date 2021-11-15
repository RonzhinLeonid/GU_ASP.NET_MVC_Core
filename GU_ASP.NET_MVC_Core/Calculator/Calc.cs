using System;

namespace Calculator
{

    public class Calc : ICalc
    {
        private IAction _action;
        public Calc(IAction action)
        {
            _action = action;
        }
        public void SetupAction(IAction action)
        {
            _action = action;
        }
        public double Execute(double x, double y)
        {
            return _action.Result(x, y);
        }
    }
}
