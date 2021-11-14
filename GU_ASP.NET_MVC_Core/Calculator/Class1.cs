using System;

namespace Calculator
{
    public class Class1
    {

    }

    public interface IResult
    {
        double Result(double x, double y);
    }
    public class Division : IResult
    {
        public double Result(double x, double y)
        {
            return x / y;
        }
    }
    public class Subtraction : IResult
    {
        public double Result(double x, double y)
        {
            return x - y;
        }
    }
    public class Sum : IResult
    {
        public double Result(double x, double y)
        {
            return x + y;
        }
    }
    public class Multiplication : IResult
    {
        public double Result(double x, double y)
        {
            return x * y;
        }
    }
    //public interface ICalc
    //{
    //    double FirstNumber { get; }
    //    double SecondNumber { get; }
    //    double Result { set; }
    //}
    public interface ICalc
    {
        double Execure(double x, double y);
    }

    public class Calc : ICalc
    {
        private readonly IResult _result;
        public Calc(IResult result)
        {
            _result = result;
        }
        public double Execure(double x, double y)
        {
            return _result.Result(x, y);
        }
    }

    public abstract class BaseController
    {
        public virtual ICalc Calc { get; set; }
    }

    public class Controller : BaseController
    {
        
    }
}
